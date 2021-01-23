     private static IEnumerable<double> AverageOfLists(params IEnumerable<double>[] values)
     {
         var lists = values.Select(v => v.ToList()).ToArray();
            
         for(var i=0;i<lists[0].Count;i++)
         {
             var sum = 0.0;
             for(var j=0;j<lists.Length;j++)
             {
                 sum+= lists[j][i];
             }
             yield return sum/lists.Length;
         }
     }
