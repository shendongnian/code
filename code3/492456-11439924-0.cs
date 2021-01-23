            StreamReader unparsedDebugInfo = GetUnparsedDebugInfo(); // get streamReader 
            listToProcess = new char[200000][];
            lastPart = null;
            matchLength = 0;
            // Used to signal events between thread that is reading text 
            // from readelf.exe and the thread that is parsing chunks
            Semaphore semaphore = new Semaphore(0, 1);
            // If task1 run out of chunks to process it will be waiting for semaphore to post a message
            bool task1IsWaiting = false;
            // Used to note that there are no more chunks to add to listToProcess.
            bool mainTaskIsDone = false;
            int counter = 0; // keep trak of which chunk we have added to the list
            // This task will be executed on a separate thread. Meanwhile the other thread adds nodes to  
            // "listToProcess" array this task will add those chunks to the dictionary. 
            var task1 = Task.Factory.StartNew(() =>
            {
                semaphore.WaitOne(); // wait until there are at least 1024 nodes to be processed
                int indexOnList = 0; // counter to identify the index of chunk[] we are adding to dictionary
                while (true)
                {
                    if (indexOnList>=counter)   // if equal it might be dangerous! 
                    {                           // chunk could be being written to and at the same time being parsed.
                        if (mainTaskIsDone)// if the main task is done executing stop
                            break;
                        task1IsWaiting = true; // otherwise wait until there are more chunks to be processed
                        semaphore.WaitOne();
                    }
                    ProcessChunk(listToProcess[indexOnList]); // add chunk to dictionary
                    indexOnList++;
                }
            });
            // this block being executed on main thread  is responsible for placing the streamreader 
            // into chunks of char[] so that task1 can start processing those chunks
            {                
                int waitCounter = 1024; // every time task1 is waiting we use this counter to place at least 256 new chunks before continue to parse them
                while (true) // more chunks on listToProcess before task1 continues executing
                {
                    char[] buffer = new char[2048]; // buffer where we will place data read from stream
                    var charsRead = unparsedDebugInfo.Read(buffer, 0, buffer.Length);
                    if (charsRead < 1){
                        listToProcess[counter] = pattern;
                        break;
                    }
                    listToProcess[counter] = buffer;
                    counter++; // add chunk to list to be proceesed by task1.
                    if (task1IsWaiting)
                    {               // if task1 is waiting for more nodes process 256
                        waitCounter = counter + 256;    // more nodes then continue execution of task2
                        task1IsWaiting = false;
                    }
                    else if (counter == waitCounter)                    
                        semaphore.Release();                    
                }
            }
            mainTaskIsDone = true; // let other thread know that this task is done
            semaphore.Release(); // release all threads that might be waiting on this thread
            task1.Wait(); // wait for all nodes to finish processing
