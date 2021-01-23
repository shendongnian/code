     using (var reader = File.OpenText("test.txt"))
     {
         char[] buffer = new char[16 * 1024];
         int charsLeft = location;
         while (charsLeft > 0)
         {
             int charsRead = reader.Read(buffer, 0, Math.Min(buffer.Length,
                                                             charsLeft));
             if (charsRead <= 0)
             {
                 throw new IOException("Incomplete data"); // Or whatever
             }
             charsLeft -= charsRead;
         }
         string line = reader.ReadLine();
         bool found = line.StartsWith(targetText);
         ...
     }
