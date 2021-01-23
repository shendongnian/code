	private void CreateWorkbook(string fileName)
	{
		using (var p = new ExcelPackage())
		{
			p.Workbook.Properties.Author = "Barry Guvenkaya";
			p.Workbook.Properties.Title = "MyTitle";
			p.Workbook.Worksheets.Add("MySheet");
			var bin = p.GetAsByteArray();
			File.WriteAllBytes(fileName, bin);
			// Below code opens the excel doc
			var proc = new Process();
			proc.StartInfo = new ProcessStartInfo(fileName)
			{
				UseShellExecute = true
			};
			proc.Start();
		}
	}
