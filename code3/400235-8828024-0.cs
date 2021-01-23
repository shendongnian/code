    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
        	unsafe{
        		byte[] byteArray = new byte[4];
        		for(int i = 0; i != int.MaxValue; ++i)
        		{
        		fixed(byte* asByte = byteArray)
        		   *((int*)asByte) = 43;
        		   }
        	}
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.Read();
        }
    }
