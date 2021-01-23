    //first create our anonymous type DTO
    var dto = new { 
        Id = 0L, 
        Source = string.Empty, 
        Destination = string.Empty, 
        Is301 = false
    };
    
    //notice the ListAs(dto) extension method
    var model = Session.QueryOver<CmsRedirect>()
      .SelectList(s => s
        .Select(x => x.Id).WithAlias(() => dto.Id)
        .Select(x => x.Source).WithAlias(() => dto.Source)
        .Select(x => x.Destination).WithAlias(() => dto.Destination)
        .Select(x => x.Do301).WithAlias(() => dto.Is301)
      )
      .Take(take).Skip(page * pageSize)
      .ListAs(dto);
    
    return Json(new { Total = total, List = model }, 
        JsonRequestBehavior.AllowGet);
