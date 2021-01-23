            string path = AppDomain.CurrentDomain.BaseDirectory;            
            var myList = new GenericMemoryMappedArray<int>(2048L*1024L*2048L, path); 
            using (myList)
            {
                myList.AutoGrow = false;
                for (int a = 0; a < (2048L * 1024L * 2048L); a++)
                {
                    myList[a] = a;
                }
            }
         
