        List<FileData> listOfData = new List<FileData>();
        void createOutputBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) 
        { 
            using (StreamReader sr = File.OpenText("D:/data.txt")) 
            { 
                String input; 
 
                while ((input = sr.ReadLine()) != null) 
                { 
                    FileData fd = new FileData(new BatchData()); 
                    string[] stringArray = input.Split(','); 
                    for (int i = 0; i < stringArray.Length - 1; i+=2) 
                    { 
                         switch(stringArray[i])
                         {
                              case "{$BATCH ID}":
                                 fd.BatchID = stringArray[i+1];
                                 break;
                              // Other properties follow ..... 
                              case ......
                         }
                    } 
                    listOfData.Add(fd);
                } 
            } 
        } 
