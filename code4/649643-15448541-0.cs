           var _result = dtResults
                .AsEnumerable()
                .GroupBy(r1 => new
                {
                    ID = r1.Field<int>("ID"),
                    Age = r1.Field<int>("Age"),
                    LastName =  r1.Field<int>("LastName"),
                    FirstName = r1.Field<int>("FirstName"),
                    Sex =  r1.Field<int>("Sex"),
                    Class =  r1.Field<int>("class"),
                    Father_Name =  r1.Field<int>("Father_Name"),
                    Mother_Name =  r1.Field<int>("Mother_Name")
                }).Select(g => new
                {
                    ID = g.Key.ID,
                    Age = g.Key.Age,
                    LastName =  g.Key.LastName,
                    FirstName = g.Key.FirstName,
                    Sex =  g.Key.Sex,
                    Class =  g.Key.Class,
                    Father_Name =  g.Key.Father_Name,
                    Mother_Name =  g.Key.Mother_Name,
                    TotalMark = g.Sum(x => x.Field<int>("Marks"))
                });
