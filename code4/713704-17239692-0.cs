    var contentTypes =
              (
                  from contentType in this._contentTypeService.GetContentTypes()
                  select new
                  {
                      id = contentType.ContentTypeId,
                      name = contentType.Name
                  }
              ).ToList();
