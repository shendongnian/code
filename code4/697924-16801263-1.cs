    var results = entityList1
                .GroupBy(e => e.DestinationId)
                .Select(e => e.First())
                .Join(entityList2, e1 => e1.DestinationId, e2 => e2.DestinationId, (e1, e2) => 
                    new EntityDTO
                    {
                        DestinationId = e1.DestinationId,
                        DestinationName = e2.DestinationName,
                        JobTitle = e1.JobTitle,
                        Name = e1.Name
                    });
