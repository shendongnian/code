    string orderProperties = "MyColumn Ascending";
    
    var orderList = _resourceRepository.Query()
                                       .OrderBy(orderProperties)
                                       .ToList();
    Mapper.CreateMap<IList<Resource>, IList<ResourceViewModel>>();
    var results = Mapper.Map<IList<Resource>>(orderList);
