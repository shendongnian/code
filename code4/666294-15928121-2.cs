            var groups = projects.GroupBy(p => p.Start.GetWeekOfMonth());
            foreach (var group in groups)
            {
                Console.WriteLine("Week {0}", group.Key);
                foreach (var project in group)
                {
                    Console.WriteLine("\t{0} | {1:dd/MM/yyyy} | {2}", 
                         project.Name, project.Start, project.Id);
                }
            }
