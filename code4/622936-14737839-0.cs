    @using (Html.BeginForm( ))
    {
        Blue : @Html.CheckBox("blueColor", true)
        Red : @Html.CheckBox("redColor", true)
        Green : @Html.CheckBox("greenColor", true) <br/>
        Black : @Html.CheckBox("blackColor", true)
        White : @Html.CheckBox("whiteColor", true)
    }
    [HttpPost]
    public ActionResult SearchIndex(string objName, string objType, string objSymbol, string objValue, string artistName, bool blueColor, bool redColor, bool greenColor, bool blackColor, bool whiteColor, bool colorless)
    {
