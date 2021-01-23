    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(
            this IEnumerable<T> source,
            IEnumerable<T> delimiter)
        {
           var delimiterList = delimiter.ToList();
           var outputBuffer = new List<T>();
           var m = 0;
           foreach(var item in source)
           {
               if item.Equals(delimiterList[m])
               {
                   m++;
                   if(m == delimiterList.Count)
                   {
                      m = 0;
                      if (outputBuffer.Count > 0)
                      {
                          yield return outputBuffer;
                          outputBuffer = new List<T>();
                      }
                   }
               }
               else
               {
                   outputBuffer.AddRange(delimiterList.Take(m));
                   m = 0;
                   outputBuffer.Add(item);
               }              
           }
           
           outputBuffer.AddRange(delimiterList.Take(m)); 
           if (outputBuffer.Count > 0)
           {
               yield return outputBuffer;
           }
       }
    }
