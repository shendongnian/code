	var book = new LinqToExcel.ExcelQueryFactory(@"File.xlsx");
	
	var query =
		from row in book.Worksheet("Stock Entry")
		let item = new
		{
			Code = row["Code"].Cast<string>(),
			Supplier = row["Supplier"].Cast<string>(),
			Ref = row["Ref"].Cast<string>(),
		}
		where item.Supplier == "Walmart"
		select item;
