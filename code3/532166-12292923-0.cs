    int readCount = File.ReadLines("readLogs.txt").Count();
    using (FileStream readLogs = new FileStream("readLogs.txt", FileMode.OpenCreate))
    using (StreamWriter writer = new StreamWriter(readLogs))
    {
         IEnumerable<string> lines = File.ReadLines(bigLogFile.txt).Skip(readCount);
         foreach (string line in lines)
         {
             // do something with line or batch them if you need more than one
             writer.WriteLine(line);
         }
    }
