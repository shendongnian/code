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
---
    var query = from w in dbo.Workers
                join d in dbo.WorkDays on w.Id equals d.Id into days
                let WorkTime = days.Sum(d => d.ExitT - d.Enter)
                select new 
                  {
                     w.Id,
                     w.Name,
                     w.Salary,
                     WorkTime,
                     Earned = WorkTime * w.Salary
                  }; 
