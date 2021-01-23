    [StructLayout(LayoutKind.Explicit)]
    struct Switcher
    {
      [FieldOffset(0)]
      public int intVal;
      [FieldOffset(0)]
      public byte b0;
      [FieldOffset(1)]
      public byte b1;
      [FieldOffset(2)]
      public byte b2;
      [FieldOffset(3)]
      public byte b3;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
    		byte[] byteArray = new byte[4];
    		Switcher swi = new Switcher();
    		for(int i = 0; i != int.MaxValue; ++i)
    		{
    		  swi.intVal = 43;
    		  byteArray[0] = swi.b0;
    		  byteArray[1] = swi.b1;
    		  byteArray[2] = swi.b2;
    		  byteArray[3] = swi.b3;
    		}
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.Read();
        }
    }
