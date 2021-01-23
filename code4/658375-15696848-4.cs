    myTable.GroupBy(t => new  {ID = t.ID})
       .Select (g => new {
                Average = g.Average (p => p.Score), 
                ID = g.Key.ID 
             })
