    _TestRepository.GetAll()
                   .GroupBy(x => x.RecordId)
                   .Select(g => g.OrderByDesceding(i => i.LMDate).First()})                                                      
                   .Select(x => new TestGridModel
                    {
                       IdName = x.Itemx.IdName,
                       LName = x.LastName,
                       FName = x.FirstName,
                       IdRecord = x.RecordId,
                       LastModifiedDate = x.LMDate
                    });
