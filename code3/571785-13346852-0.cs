    var list = from item in ObjectContext.Plants
               where item.ID == ID
               select new Model()
               {
                   ID = item.ID,
                   Name = item.Name,
                   Status = item.GetRangeStatus() // <====
               };
    return list;
