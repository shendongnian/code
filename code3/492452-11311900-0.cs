       StreamReader sr = GetUnparsedDebugInfo(); // get streamReader                        
            
       var task1 = Task.Factory.StartNew(() =>
       {
           Thread.Sleep(500); // wait a little so there are items on list (listToProcess) to work with
           StartProcesingList();
       });
       int counter = 0;
       while (true)
       {
           char[] buffer = new char[2048]; // crate a new buffer each time we will add it to the list to process
           var charsRead = sr.Read(buffer, 0, buffer.Length);
           if (charsRead < 1) // if we reach the end then stop
           {
               break;
           }
           listToProcess[counter] = buffer;
           counter++;
       }
       task1.Wait();
