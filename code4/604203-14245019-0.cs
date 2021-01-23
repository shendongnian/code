    public static void Method(params object[] list) 
    {
      for ( int i = 0 ; i < list.Length ; i++ )
          Console.WriteLine(list[i]);
    }
    Method(1, 'a', "test"); 
