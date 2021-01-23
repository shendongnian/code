    var lookup = listOfDetails.ToLookup(x => new { x.CustomerNumber, x.ID });
    foreach(var item in customerDetails)
    {
        var key = new { CustomerNumber = item.CustomerNum, item.ID };
        item.SomeDetails = lookup[key].ToList();
    }
