    protected IEnumerable<string> GetErrorsFromModelState()
    {
        var items = ModelState.SelectMany(x => x.Value.Errors
            .SelectMany(error => 
                              {
                                  var e = new List<string>();
                                  e.Add(error.Exception);
                                  e.Add(error.ErrorString);
                                  return e;
                              }));
        return items;
    }
