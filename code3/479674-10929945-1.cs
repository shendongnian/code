    @{ Html.Telerik().Menu()
         .Name("Menu")
         .Items(menu =>
         {
           menu.Add()
           .Text("Address")
           .Action("index", "basicdata", new { basicdatatype = BasicDataType.ADDRESS, area = "basicdata" });
         }).Render();
     }
