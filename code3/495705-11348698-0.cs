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
               if item.Equals(delimeterList[m])
               {
                   m++;
                   if(m > delimiterList.Length)
                   {
                      m = 0;
                      if (outputBuffer.Length > 0)
                      {
                          yield return outputBuffer;
                          outputBuffer.Clear();
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
           if (outputBuffer.Length > 0)
           {
               yield return outputBuffer;
           }
       }
    }
