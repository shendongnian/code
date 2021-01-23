        var list = _dictImportantInformation.GetList().ToList().Select(
            x => new DictionaryNewInfoListModel
                     {
                         Id = x.Id,
                         CityId = 1,
                         Description = x.Description,
                         IsActiveYN = x.IsActive,
                         DeestynationName = x.DictImportantInformationXDestination.Select(n => new DictionaryNewInfoSupportList 
                         { Id = n.Destination.Id, Name = n.Destination.Description }).ToList()
                     }
            ).ToList();
