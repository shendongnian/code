            List<Project> lst = lst1.Union(lst2).Union(lst3).ToLookup(x => x.ProjectId).Select(x => new Project()
            {
                ProjectId = x.Key,
                ProjectName = x.Select(y => y.ProjectName).Aggregate((z1,z2) => z1 ?? z2),
                Customer = x.Select(y => y.Customer).Aggregate((z1, z2) => z1 ?? z2),
                Address = x.Select(y => y.Address).Aggregate((z1, z2) => z1 ?? z2)
            }).ToList();
