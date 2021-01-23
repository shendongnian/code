    var listA = new List<Row> { 
        new Row { ID= 1, IdNum = 1, IdCust = 1 }, 
        new Row { ID= 2, IdNum = 1, IdCust = 2 }, 
        new Row { ID= 3, IdNum = 2, IdCust = 1 }, 
        new Row { ID= 4, IdNum = 1, IdCust = 3 }, 
        new Row { ID= 5, IdNum = 3, IdCust = 1 }, 
        new Row { ID= 6, IdNum = 4, IdCust = 1 } 
    };
    
    var listB = new List<Row> { 
        new Row { ID= 1, IdNum = 5, IdCust = 1 }, 
        new Row { ID= 5, IdNum = 6, IdCust = 2 }, 
        new Row { ID= 7, IdNum = 2, IdCust = 1 }, 
        new Row { ID= 9, IdNum = 1, IdCust = 3 }, 
        new Row { ID= 11, IdNum = 7, IdCust = 2 }
    };
    
        var t = (from a in listA
                 join b in listB on a.IdCust.ToString() + a.IdNum.ToString() 
                 equals 
                 b.IdCust.ToString() + b.IdNum.ToString()
                 select new
                 {
                    ID = a.ID,
                    IdUpdate = b.ID
                 }).ToArray();
    
    foreach (var item in t)
    {
        Console.WriteLine("ID {0} IdUpdate {1}", item.ID, item.IdUpdate);
    }
