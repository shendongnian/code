            List<Project> projects = null;
            var weeksAndHours = projects
                .Select(p => new 
                {
                    Id = p.Id,
                    Name = p.Name,
                    Weeks = p
                        .SubProjects.SelectMany(sp => sp.Weeks)
                        .Where(w => w.Week >= 30 && w.Week <= 35)
                        .GroupBy(w => w.Week)
                        .Select(g => new { week = g.Key, hours = g.Sum( w=> w.Hours) })
                });
