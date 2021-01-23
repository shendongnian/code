    var listOfB = session.Query<B>()
        .Select(b => new BViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Date = b.Date,
                ItemA = new AViewModel 
                    {
                        Id = b.ItemA.Id,
                        Number = b.ItemA.Number,
                    },
            }).ToList();
