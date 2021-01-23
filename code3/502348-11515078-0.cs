    var query =
        from s in Students
        join d in SickDays on s.ID equals d.Student_ID into gj
        from sd in gj.DefaultIfEmpty()
        group sd by new { s.Name, s.Order } into gg
        select
            new
            {
                Name = gg.Key.Name,
                Order = gg.Key.Order,
                Count = gg.Count(x => x != null && x.Class_ID == myId)
            };
