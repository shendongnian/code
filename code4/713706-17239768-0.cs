    var allTypes = new[]{new { id = 99, name = "All" }};    // creates a fixed anonymous type as `IEnumerable<T>`
    var contentTypes = from contentType in this._contentTypeService.GetContentTypes()
                       select new
                       {
                           id = contentType.ContentTypeId,
                           name = contentType.Name
                       };
    var result = allTypes.Concat(contentTypes).ToList(); // concat 
