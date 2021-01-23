    if (HttpContext.Current.Session[listModelType + "ListModel"] != null)
    {
    
        listModel = JsonConvert.DeserializeObject<*CLASS name of lsitmodel*>((string)HttpContext.Current.Session[listModelType + "ListModel"]);
                 
    }
