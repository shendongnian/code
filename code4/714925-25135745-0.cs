    [StepDefinition(@"I select cell (.+)")]
    public void WhenIClickOnExcelCellX(string cell)
    {
        excelDriver.SelectCell(cell);
    }
