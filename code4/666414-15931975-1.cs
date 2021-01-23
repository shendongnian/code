        string fileName = Console.ReadLine();
        using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
            byte[] output = new byte[file.Length]; // reversed file 
            // read the file backwards using SeekOrigin.Current
            //
            long offset;
            file.Seek(0, SeekOrigin.End);        
            for (offset = 0; offset < fs.Length; offset++)
            {
               file.Seek(-1, SeekOrigin.Current);
               output[offset] = file.ReadByte();
               file.Seek(-1, SeekOrigin.Current);
            }
                
            // write entire reversed file array to new file
            //
            File.WriteAllBytes("newsFile.txt", output);
        }
