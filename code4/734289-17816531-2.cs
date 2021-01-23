    [Test]
    [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Invalid ending parameter of the workbook. Please use .xlsx random random")]
    public void ArgumentsWorkbookNameException()
    {
    	const string workbookName = "Tester.xls";
    	var args = new[] { workbookName, "Sheet1", "Source3.csv", "Sheet2", "Source4.csv" };
    	new ApplicationArguments(args);
    }
