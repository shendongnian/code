                using (ExcelPackage pck = new ExcelPackage())
            {
                //Give the worksheet a name
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Inventory as of " + DateTime.Now.ToString("MM/dd/yyyy"));
                //dt is a datable that i am turning into an excel document
                ws.Cells["A1"].LoadFromDataTable(dt, true);
                //Format the header columns(Color,Pattern,etc.)
                using (ExcelRange rng = ws.Cells["A1:AA1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;             //Set Pattern for the background to Solid
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                    rng.Style.Font.Color.SetColor(Color.White);
                }
                //End Format the header columns
                //Give the file details(ie. filename, etc.)
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Inventory Report " + DateTime.Now.ToString("MM/dd/yyyy") + ".xlsx");
                //Write the file
                Response.BinaryWrite(pck.GetAsByteArray());
                Response.End();
                pck.Save();
            }
