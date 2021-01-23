     using (AppDbContext db = new AppDbContext())
                {
                    //select "Field1, Field2" from entity
                    var result = db.SampleEntity.Select(Helpers.DynamicSelectGenerator<SampleEntity>("Field1, Field2")).ToList();
                    //select all field from entity
                    var result1 = db.SampleEntity.Select(Helpers.DynamicSelectGenerator<SampleEntity>()).ToList();
                }
