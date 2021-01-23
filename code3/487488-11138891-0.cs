    public static void Main()
       {
           
          byte[] bytes = {75, 2, 0, 0, 1, 0, 0, 0};
          int result = BitConverter.ToInt32(bytes, 0);
          Console.WriteLine("Returned value: {0}", result);
          Console.ReadLine();
       }
