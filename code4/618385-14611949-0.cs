    DataContext.GetTable<Employee>()
        .Select(e => new { e.ID, e.Name, e.Branch_ID })
        .Union(DataContext.GetTable<Manager>()
                .Select(m => new { m.ID, m.Name, m.Branch_ID }))
        .Join(DataContext.GetTable<Branch>(), 
                u => new { Branch_ID = u.Branch_ID },
                b => new { Branch_ID = (int?)b.ID },
                (u, b) => new { u.ID, u.Name, u.Branch_ID, b.Branch_Name })
        .Select(j => new { j.ID, j.Name, j.Branch_ID, j.Branch_Name });
