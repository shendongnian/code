    public static byte[] myarray;
    
    static void Main(string[] args)
    {
    
        FileStream strm = new FileStream(@"some.txt", FileMode.Open, FileAccess.Read,
            FileShare.Read, 1024, FileOptions.Asynchronous);
    
        myarray = new byte[strm.Length];
        IAsyncResult result = strm.BeginRead(myarray, 0, myarray.Length, new
        AsyncCallback(CompleteRead),strm );
        Console.ReadKey();
    }
    
        private static void CompleteRead(IAsyncResult result)
        {
              FileStream strm = (FileStream)result.AsyncState;
              int size = strm.EndRead(result);
        
              strm.Close();
              //this is an example how to read data.
              Console.WriteLine(BitConverter.ToString(myarray, 0, size));
        }
