    public void ClearModelState()
    {
        var modelStateKeys = ModelState.Keys;
        var formKeys = Request.Form.Keys.Cast<string>();
        var allKeys = modelStateKeys.Concat(formKeys).ToList();
    
        var culture = CultureInfo.CurrentUICulture;
    
        foreach (var key in allKeys)
        {
            ModelState[key] = new ModelState { Value = new ValueProviderResult(null, null, culture) };
        }
    }
