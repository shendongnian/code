    var data = DataContext.ObjectSet
                 .Select(rec => new SessionData() { Title = rec.Title , Count = rec.Count })
                 .ToList();
    System.Web.Script.Serialization.JavaScriptSerializer oSerializer = 
         new System.Web.Script.Serialization.JavaScriptSerializer();
    Session["Data"] = oSerializer.Serialize(data);
