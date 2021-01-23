    using Should;
    [Then(@"cell (.+) should be selected")] //Regex might need changing
    public void ThenCellXShouldBeSelected(string cell)
    {
         excelDriver.IsSelected(cell).ShouldBeTrue(); //Or whatever the call is
    }
