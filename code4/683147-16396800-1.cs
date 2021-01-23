    public ClassName[] CreateClassNames(string[,] list)
    {
         List<ClassName> result = new List<ClassName>()
         for ( int i = 0 ; i < list.GetLength(0); i++ )
         {
            result.Add(new ClassName(list[i][0], list[i][1]));
         }
         return result.ToArray();
    }
