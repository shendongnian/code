        (...
        select new 
        { 
            Name = timeline.Name, 
            DisplayName = TimeModels.ExternalId !=null ? TimeModels.Name : timeline.circuitName
        })
        .AsEnumerable()
        .Select(x=> new Items()
         {
                  Name = x.Name
                  DisplayName = x.DisplayName.ToString()
         };
