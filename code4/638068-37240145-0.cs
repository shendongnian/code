    @{
        ViewBag.Title = "Index";
    
        PartialViewTestSOl.Models.CountryModel ctry1 = new PartialViewTestSOl.Models.CountryModel();
        ctry1.CountryName="India";
        ctry1.ID=1;
    
    
        PartialViewTestSOl.Models.CountryModel ctry2 = new PartialViewTestSOl.Models.CountryModel();
        ctry2.CountryName="Africa";
        ctry2.ID=2;
    
        List<PartialViewTestSOl.Models.CountryModel> CountryList = new List<PartialViewTestSOl.Models.CountryModel>();
        CountryList.Add(ctry1);
        CountryList.Add(ctry2);
    
    
    }
    <h2>Index</h2>
    @{
        Html.RenderPartial("~/Views/PartialViewTest.cshtml",CountryList );
    }
