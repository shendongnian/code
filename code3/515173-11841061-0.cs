    @using (Html.BeginForm("Index", "Home")) {    
    <p>
    Page number:
    @Html.TextBox("CountryId")
    <input type="submit" value="CountryId" />
    </p>
    }
    [HttpPost]
    public ActionResult Index(int countryId)
    { 
    CountryId= countryId;
    }
