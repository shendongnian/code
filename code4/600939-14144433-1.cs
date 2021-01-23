    @using (Html.BeginForm("Mday", "Metrics", FormMethod.Get))
    {
        @Html.DropDownListFor(x => x.SelectedMonth, Model.GetMonthsSelectList())
        @Html.DropDownListFor(x => x.SelectedYear, Model.GetYearsSelectList())
    
        <input type="submit" />
    }
    @if (Model.CanShowChart)
    {
        <img src="@Url.Action("ValidateChart", new { month = Model.SelectedMonth, year = Model.SelectedYear })" alt="Test"/>
    }
