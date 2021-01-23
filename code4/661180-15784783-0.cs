    var groupdResults = 
    from result in response.Results
    orderby result[SearchSmartFormProperty.GetDateProperty("/root/FundClosingDate")]
    group result by result[SearchSmartFormProperty.GetStringProperty("/root/DeadlineAltText")] 
    into statusGroup
    select new ResultObject
    { 
        closingDate = statusGroup.First().ClosingDate,
        ....
    };
