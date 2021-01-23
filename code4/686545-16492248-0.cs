    public static void UseParams2(params object[] list) 
    {
       for ( int i = 0 ; i < list.Length ; i++ )
          Console.WriteLine(list[i]);
       Console.WriteLine();
    }
