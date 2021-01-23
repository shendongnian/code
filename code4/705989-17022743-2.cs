    var paramValues = HttpContext.Current.Request.Params.GetValues("listOfIds");
    if (paramValues != null)
    {
       foreach (var id in paramValues)
       {
            int result; 
            if (Int32.TryParse(id, out result))
                model.Add(GetValueForId(Add(result));
            else
               // error handling
        }
    }
