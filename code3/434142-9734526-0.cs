    using (var reader = new BinaryReader(File.Open(filename, FileMode.Open)))
    {
         System.Int16[] buffer = new System.Int16[1024];                
         for (int i = 0; i < 1024; i++)
         {
             buffer[i] = reader.ReadShort();
         }                
    }
