    [HttpPost]
     public ActionResult AddMenu(string menuType, Menu menu, string menuTitle)
     {
         var serializer = new JavaScriptSerializer();
         var newMenu = serializer.Deserialize<Menu>(menu);
      }
