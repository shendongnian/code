    using (var document = SpreadsheetDocument.Open(stream, true))
			{
				var sheets = document.WorkbookPart.Workbook.Descendants<Sheet>();
				foreach (Sheet sheet in sheets)
				{
					WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(sheet.Id);
					Worksheet worksheet = worksheetPart.Worksheet;
					var rows = worksheet.GetFirstChild<SheetData>().Elements<Row>();
					foreach (var row in rows)
					{
						var cells = row.Elements<Cell>();
						foreach (var cell in cells)
						{
							if(GetColumnName(cell.CellReference) == "A")
							{
								var str = cell.CellValue.Text;
								// do whatewer you want
							}
						}
					}
				}
			}
