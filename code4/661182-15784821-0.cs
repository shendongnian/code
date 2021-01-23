    var groupdResults = 
        from result in response.Results
        orderby result[SearchSmartFormProperty.GetDateProperty("/root/FundClosingDate")]
        group result by result[SearchSmartFormProperty.GetStringProperty("/root/DeadlineAltText")] 
        into statusGroup
        select new 
        { 
            closingDate =statusGroup.Key,
            count= statusGroup.Count
            items = statusGroup.Select(g => new {g.title, g.closingdate, ... })
        };
