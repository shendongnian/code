	Workbook workBook = _excelApp.Workbooks.Open(thisFileName);
	
	for (int itm = 1; itm < workBook.Connections.Count + 1; itm++) {
		Console.WriteLine(workBook.Connections[itm].Type + "\n" +
			workBook.Connections[itm].OLEDBConnection.CommandText + "\n" +
			workBook.Connections[itm].OLEDBConnection.CommandType + "\n" +
			workBook.Connections[itm].OLEDBConnection.Connection + "\n" +
			workBook.Connections[itm].OLEDBConnection.SourceDataFile);
		Console.Read();
	}
