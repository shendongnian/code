     from s in db.Students
     select new
     {
         s.Name,
         s.Surname,
         Birthday = new DateTime((int)(object)(s.dateStr.Substring(0, 4)),
                                 (int)(object)(s.dateStr.Substring(4, 2)),
                                 (int)(object)(s.dateStr.Substring(6, 2))),
     }
