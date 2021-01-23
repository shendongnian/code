    var workers = from ll in dbo.Workers
                  join p in dbo.WorkDays on ll.Id equals p.Id
                  orderby p.Enter
                  select new WorkerInfo
                  {
                     Id = ll.Id,
                     Name = ll.Name,
                     Salary = ll.Salary,
                     Enter = p.Enter,
                     ExitT = p.ExitT,
                     Place = p.Place
                  }; 
