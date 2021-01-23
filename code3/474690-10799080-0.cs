    var mergedProjects =
        lst1
            .Join(lst2,
                proj1 => proj1.ProjectID,
                proj2 => proj2.ProjectID,
                (proj1, proj2) => new { Proj1 = proj1, Proj2 = proj2 })
            .Join(lst3,
                pair => pair.Proj1.ProjectID,
                proj3 => proj3.ProjectID,
                (pair, proj3) => new Project
                {
                    ProjectID = proj3.ProjectID,
                    ProjectName = pair.Proj1.ProjectName,
                    Customer = pair.Proj2.Customer,
                    Address = proj3.Address
                });
