    var emp = dbContext.Employees.Select(x =>
                                                {
                                                    var rv = new Employee()
                                                                {
                                                                    name = x.name
                                                                };
                                                    rv.Obj.DOB = x.DOB;
                                                    rv.Obj.BirthPlace = x.BirthPlace;
                                                    return rv;
                                                }).ToList();
