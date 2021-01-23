    public static void foo(string[] ss)
    {
      if(ss!=null && ss.Length > 0)
        ss[0] = "Overwritten";
    }
    public static void main()
    {
       var strings = new[] { String.Empty, "Original" };
       foo(strings);
       Console.WriteLine(strings[0]); //will print 'Overwritten'.
    }
