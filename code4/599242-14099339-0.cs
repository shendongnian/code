     var list = new List<DateTime>();
     list.Add(new DateTime(1980, 5, 12));
     list.Add(new DateTime(1960, 1, 2));
     list.Add(new DateTime(1983, 5, 4));
     list.Add(new DateTime(1999, 10, 11));
     list.Add(new DateTime(1913, 4, 7));
    
     DateTime max = DateTime.MinValue;
    
     foreach (DateTime d in list)
     {
         if (d > max)
             max = d;
     }
