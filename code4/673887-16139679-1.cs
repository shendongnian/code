    var rows = 
            from rec in context.tblLogs.AsEnumerable()
            join rec1 in context.tblLogs.AsEnumerable().Where(t => t.DateAdded == refDate && t.IsDeleted == 0)
                on rec.EmpID equals rec1.EmpID
            where rec.DateAdded == refDate && rec.IsDeleted == 0 && !rec.Remarks.Contains("proxy date used") && rec.RecType == recType
            group rec by rec.EmpID into g
            select new
            {
                g.Key,
                lim = (g.Count() > 10 ? Math.Floor(g.Count() / 10) : 1).ToString(),
                InternalIDS = string.Join("", g.OrderBy(s => s.internalid).Select(s => s.internalid))
            };
