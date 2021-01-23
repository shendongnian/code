    class Program
    {
        static byte[] buffer;
        static int InputReportLength = 1024;
        static FileStream fileStream;
        public static void Main()
        {
            BeginAsyncRead();
        }
        private static void BeginAsyncRead()
        {
            buffer = new Byte[InputReportLength];
            fileStream = File.OpenRead("Data.txt");
            // put the buff we used to receive the stuff as the async state then we can get at it when the read completes
            fileStream.BeginRead(buffer, 0, InputReportLength, ReadCompleted, buffer);
        }
        private static void ReadCompleted(IAsyncResult iResult)
        {
            Byte[] buffer = (Byte[])iResult.AsyncState; // retrieve the read buffer
        }
    }
