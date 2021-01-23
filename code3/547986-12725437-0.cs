    public static void Main(string[] args)
    {
         var ia = new byte[args.Length];
         for (int i = 0; i < args.Length; i++)
         try
         {
            ia[i] = Convert.ToByte(args[i]);
         }
         catch (FormatException e)
         {
         }
       System.Console.WriteLine(String.Format("{0:X}",Calc(ia, ia.Length))); /// I assume Calc is function return something
    }
