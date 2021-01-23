           List<int> split(int num,int splitBy)
               {
                  
                   List<int> r = new List<int>();
                   int v = Convert.ToInt32(num / splitBy);
                   r.AddRange(Enumerable.Repeat(splitBy, v).ToArray());
                   var remaining = num % splitBy;
                   if (remaining != 0)
                       r.Add(remaining);
                   return r;
        
               }
