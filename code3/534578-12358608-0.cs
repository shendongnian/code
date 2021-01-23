        static private void WriteMMF()
        {
            // data that we write to the file. we will get this a tcp
            var data = System.Text.Encoding.UTF8.GetBytes("Hello World 2");
            using (var fileStream = new FileStream(@"C:\Temp\SomeFile.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            using (MemoryMappedFile memoryMapped = MemoryMappedFile.CreateFromFile(fileStream, "MapName", 1024,
                MemoryMappedFileAccess.ReadWrite, new MemoryMappedFileSecurity(), HandleInheritability.Inheritable, true))
            {
                var viewStream = memoryMapped.CreateViewStream();
                viewStream.Write(data, 0, data.Length); // write hello world                                
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Writing MMF");
            WriteMMF();
            Console.WriteLine("Done.  Press a key.");
            var ch = Console.ReadKey();
            return;
        }
