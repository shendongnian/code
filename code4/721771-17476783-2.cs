            using (EncryptingFileStream fs = new EncryptingFileStream("test.crypt", DX_KEY_32, DX_IV_16))
            {
                string line;
                // Read and display lines from the file until the end of  
                // the file is reached. 
                while ((line = fs.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
