    Boolean isSaving = true, savedOk = false;                  
    new Task(new Action(() =>
    {
        try
        {
            string fileName = "filename.txt";
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                BinaryReader br = new BinaryReader(fs);
                long size = new FileInfo(fileName).Length;
                int bytesPerRead = (int)(size < 512000 ? size : 512000);
                byte[] past = br.ReadBytes(bytesPerRead);
                int offset = 0;
                while (offset < size)
                {
                    //TODO - SAVE YOUR BYTE ARRAY TO DB USING WCF OR LOCAL PROC 
                                  
                    offset = offset + bytesPerRead;
                    bytesPerRead = (int)(size - offset < 512000 ? size - offset : 512000);
                    past = br.ReadBytes(bytesPerRead);                                    
                }
                savedOk = true;
           }
        }
        catch (Exception ex) { savedOk = false; }
        isSaving = false;                        
     })).Start();
     while (isSaving) 
     { 
        //DOUPDATES 
     };
