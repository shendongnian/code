    class Program
    {
        static Byte[] buffer = new Byte[1024];
        public static void Main()
        {
            FileStream fileStream = File.OpenRead("data.txt");
            fileStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(FileReadCallback), fileStream);
            Console.ReadLine();
        }
        public static void FileReadCallback(IAsyncResult result)
        {
            FileStream fileStream = (FileStream)result.AsyncState;
            fileStream.EndRead(result);
            foreach (Byte b in buffer)
                Console.Write((Char)b);
            
        }
    }
