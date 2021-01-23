    using System.Collections.Generic;
    using System.IO;
    using System.IO.MemoryMappedFiles;
    
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();
        }
    
        private void Start()
        {
            string fileName = @"C:\Source\Numbers.txt";
            var file = MemoryMappedFile.CreateFromFile(fileName);
            var stream = file.CreateViewStream();
            long sizeInBytes = new FileInfo(fileName).Length;
    
            using (var reader = new StreamReader(stream))
            {
                List<char> read = new List<char>();
                List<int> readInts = new List<int>();
                long readBytes = 0;
                int ch;
                while( (ch = reader.Read()) != -1 && readBytes <= sizeInBytes)
                {
                    readBytes += 2;
                    if (ch == ' ' || ch == '\r' || ch == '\n' && read.Count > 0)
                    {
                        readInts.Add(
                            int.Parse(new string(read.ToArray()))
                            );
                        read.Clear();
                    }
                    else
                    {
                        read.Add((char)ch);
                    }
                }
    
                if (read.Count > 0)
                {
                    readInts.Add( int.Parse(new string(read.ToArray())) );
                }
            }
        }
    }
