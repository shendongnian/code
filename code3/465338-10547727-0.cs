    protected void BtnExcelExport_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
    	try {
    		var pck = new OfficeOpenXml.ExcelPackage();
    		var ws = pck.Workbook.Worksheets.Add("Name of the Worksheet");
    		// get your DataTable
            var tbl = GetDataTable();
    		ws.Cells("A1").LoadFromDataTable(tbl, true, OfficeOpenXml.Table.TableStyles.Medium6);
    		foreach (DataColumn col in tbl.Columns) {
    			if (col.DataType == typeof(System.DateTime)) {
    				var colNumber = col.Ordinal + 1;
    				var range = ws.Cells(1, colNumber, tbl.Rows.Count, colNumber);
                    // apply the correct date format, here for germany
    				range.Style.Numberformat.Format = "dd.MM.yyyy";
    			}
    		}
    		var dataRange = ws.Cells(ws.Dimension.Address.ToString());
    		dataRange.AutoFitColumns();
    
    		Response.Clear();
    		Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    		Response.AddHeader("content-disposition", "attachment;  filename=NameOfExcelFile.xlsx");
    		Response.BinaryWrite(pck.GetAsByteArray());
    	} catch (Exception ex) {
            // log exception
            throw;
    	} 
        Response.End();
    }
