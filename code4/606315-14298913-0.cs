    var businessCodes = personCodeStore.GetBusinessCodes();
    return Json(businessCodes.Select(x => new 
    {
        value = x.TypeId,
        text = x.Code
    }));
