       foreach (int b in B)
       {
          var S = A.Where(n => n % 4 == b);
          newlist.AddRange(S); 
       }
       var result = newlist.Distinct().ToList();
