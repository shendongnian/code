    public ClassName[] CreateClassNames(params string[] list)
    {
         List<ClassName> result = new List<ClassName>()
         for ( int i = 0 ; i < string.Length ; i += 2 )
         {
            result.Add(new ClassName(list[i], list[i+1]));
         }
         return result.ToArray();
    }
