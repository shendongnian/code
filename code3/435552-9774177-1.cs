    public static void foo(string[] ss)
    {
      if(ss==null || ss.Length == 0)
        ss= new string[1];
      ss[0] = "Overwritten";
    }
    public static void main()
    {
       string[] strings = null
       foo(strings);
       Console.WriteLine(strings[0]); //will still print 'Overwritten'.
    }
