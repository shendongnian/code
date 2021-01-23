    using (StreamWriter wr = new StreamWriter(File.Create(@"c:\Temp\aaa.txt")))
    {
       wr.Write("ABC");
       wr.Flush();
       wr.BaseStream.Seek(0, SeekOrigin.Begin);
       wr.Write("Z");                
    }
