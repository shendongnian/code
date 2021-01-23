	FileInfo newFile = new FileInfo(@"C:\Temp\sample300.xlsx");
	if (newFile.Exists)
	{
		newFile.Delete();  // ensures we create a new workbook
		newFile = new FileInfo(@"C:\Temp\sample300.xlsx");
	}
	using (ExcelPackage package = new ExcelPackage(newFile))
	{
		// add a new worksheet to the empty workbook
		ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Inventory");
		//Add the headers
		worksheet.Cells[1, 1].Value = "ID";
		worksheet.Cells[1, 300].Value = "Col 300";
		package.Save();
	}
