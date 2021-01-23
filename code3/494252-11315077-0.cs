    var status = from a in ObjectContext.InspectionReadings
                 where a.InspectionID == new Guid(inspID)
                 && a.DateTaken > before
                 && a.DateTaken <= DateTime.Now
                 group a by a.DateTaken.Month into g
                 from m in g
                 select new 
                 {
                   g.Key, g.OrderBy(x => x.DateTaken).First()
                 };
                 
