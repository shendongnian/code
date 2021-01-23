    var idString = Page.RouteData.Values["id"] as string;
    int id;
    if (!string.IsNullOrWhiteSpace(idString) && int.TryParse(idString, out id))
    {
       // id is now a valid number 
    }
    else
    {
       // your types are confused
    }
