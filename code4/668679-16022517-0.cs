            HasMany<City>(x => x.ListCity)
                // Provide column key to reference by
                .KeyColumnNames.Add("REGION_ID")
                .Inverse()
                .Cascade.SaveUpdate()
                .AsBag();
