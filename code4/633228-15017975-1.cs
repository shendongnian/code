               i.Add(new SomeClass
                         {
                            ID = sql.GetInt32(0).ToString(), 
                            FirstName = sql.GetString(1),
                            LastNamre = sql.GetString(2),
                            Age = sql.GetInt32(3),
                            School = sql.GetString(4)
                         });
