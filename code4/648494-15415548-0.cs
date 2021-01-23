    @using (Html.BeginForm("Index", "Home", "POST"))
    {
    <div class="searchField">
        <div class="searchbox">
            Search: <input type="text" name="Search" />
            <input type="submit" value="Submit">
        </div>
    </div>
    }
    
    
     @Html.Partial("PartialAnalysis", (string)ViewBag.SearchKey)
     @Html.Partial("PartialSlag", (string)ViewBag.SearchKey)
    //In Home Controller
    [HttpPost]
    public ActionResult Index(string Search)
    {
        ViewBag.SearchKey = Search;
        return View();
    }
