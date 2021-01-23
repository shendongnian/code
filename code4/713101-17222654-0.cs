      using(var inputFile = new FileStream(
             "oldFileName.txt", 
             FileMode.Open, 
             FileAccess.Read, 
             FileShare.Read))
         {
            using (var outputFile = new FileStream("newFileName.txt", FileMode.Create))
            { 
                var buffer = new byte[0x10000];
                int bytes;
    
                while ((bytes = inputFile.Read(buffer, 0, buffer.Length)) > 0) 
                {
                    outputFile.Write(buffer, 0, bytes);
                }
            }
        }
