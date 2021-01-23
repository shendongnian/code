    //must be done completely. How do I ensure it?
        private static void WorkOnFile(string fileName)
        {
            while(true){
                try{
                    using (FileStream f = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        Thread.Sleep(40000); // some long operations
                       
                        break; //exit while() infinite loop
                    }
                }
                catch(Exception e){
                    //file is locked because being written. wait a few seconds then retry
                    Thread.Sleep(10000);
                }     
            }       
        }
