        void StartProcesingList()
        {
            int indexOnList = 0;
            while (true)
            {
                if (listToProcess[indexOnList] == null)
                {
                    Thread.Sleep(100); // wait a little in case other thread is adding more items to the list
                    if (listToProcess[indexOnList] == null)
                        break;
                }
               
                // add chunk to dictionary if you recall listToProcess[indexOnList] is a 
                // char array so it basically converts that to a string and splits it where appropiate
                // there is more logic as in the case where the last chunk will have to be 
                // together with the first chunk of the next item on the list
                ProcessChunk(listToProcess[indexOnList]);
                indexOnList++;                
            }
            
        }
