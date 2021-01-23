    var result = (from row in table.AsEnumerable()
                    let projection = from fieldName in fields
                                    select new { Name = fieldName, Value = row[fieldName] }
                    group projection by projection.Aggregate((v, p) =>
                        new {
                            Name = v.Name + p.Name, 
                            Value = (object)String.Format("{0}{1}", v.Value, p.Value)
                        }) into g
                    select g.FirstOrDefault().ToDictionary(p=>p.Name,p=>p.Value));  
