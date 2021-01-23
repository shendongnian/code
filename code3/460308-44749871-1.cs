                List<bocls> list6 =  new List<bocls>();
               //copy the grid view values into list
				list6 = (from row in dataGridView1.Rows.Cast<DataGridViewRow>()
				from cell in row.Cells.Cast<DataGridViewCell>()
				select new 
				{
					//project into your new class from the row and cell vars.
				}).ToList();
        }
                ExcelPackage excel = new ExcelPackage();
                var workSheet = excel.Workbook.Worksheets.Add("Products");
                var totalCols = GridView1.Rows[0].Cells.Count;
                var totalRows = GridView1.Rows.Count;
                var headerRow = GridView1.HeaderRow;
                for (var i = 1; i <= totalCols; i++)
                {
                    workSheet.Cells[1, i].Value = headerRow.Cells[i - 1].Text;
                }
                for (var j = 1; j <= totalRows; j++)
                {
                    for (var i = 1; i <= totalCols; i++)
                    {
                        var item = list6.ElementAt(j - 1);
                        workSheet.Column(1).Width = 13;
                        workSheet.Column(2).Width = 10;
                       
                        workSheet.Cells[j + 1, i].Style.WrapText = true;
                        if (headerRow.Cells[i - 1].Text == "ID")
                            workSheet.Cells[j + 1, i].Value = item.GetType().GetProperty("id").GetValue(item, null);
                        else if (headerRow.Cells[i - 1].Text == "NAME")
                            workSheet.Cells[j + 1, i].Value = item.GetType().GetProperty("name").GetValue(item, null);
                        
                        workSheet.Cells[j + 1, i].Value = workSheet.Cells[j + 1, i].Value.ToString().Replace("<br/>", "");
                    }
                }
                using (var memoryStream = new MemoryStream())
                {
                   
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    string filename = Guid.NewGuid().ToString() + ".xlsx";
                    Response.AddHeader("content-disposition", "attachment;  filename=" + filename);
                    excel.SaveAs(memoryStream);   
					//add your destination folder
                    FileStream fileStream = new FileStream(@"C:\Users\karthi\Downloads\New folder\" + filename, FileMode.Create,FileAccess.Write,FileShare.Write);
                    memoryStream.WriteTo(fileStream);
                    fileStream.Close();
                    memoryStream.WriteTo(Response.OutputStream);
                    memoryStream.Close();
                    memoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            
        }
    
   
