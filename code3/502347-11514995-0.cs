    (from a in SickDays
        join b in Class.Where(p => p.ID == myId) on a.Class_ID equals b.ID
        join c in Student on a.Student_ID equals c.ID
            into s
        from students in s.DefaultIfEmpty()
        group a by new { students.Name, students.Order } into ac
        select new { Count = ac.Count(), Name = ac.Key.Name, Order = ac.Key.Order }
    ).OrderBy(f => f.Order)
