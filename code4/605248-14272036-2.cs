     var results = dataTable.AsEnumerable()
                       .GroupBy(x=> x.Field<string>("Profession"))
                       .Select (  grouping => 
                                   new {
                                      Key=grouping.Key,
                                      CombinedProfession = grouping.Aggregate( (a,b)=> a + " " + b)
                                    })
                        .Select (x=> new ProfessionRecord
                                {
                                  Id = x.Key.Id,
                                  Name = x.Key.Name,
                                  Profesion = x.CombinedProfession,
                                });
