    using (var context = new Context())
    {
        context.LazyLoadingEnabled = false;
        var r = context.MasterData.Include("DetailData")
    		.Select(d => new MasterDTO()
    		{
    			Id = d.Id,
    			Name = d.Name,
    			Details = d.Details.Select(dt => new DetailDTO()
    			{
    				Id = dt.Id,
    				DetailName = dt.DetailName
    			})
    		});
    }
