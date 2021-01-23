    if (FileUpload1.HasFile)
            {
                
                HttpPostedFile file = Request.Files[0];
                myLabel.Text = file.FileName;
                MemoryStream mem = new MemoryStream();
                mem.SetLength((int)file.ContentLength);
                file.InputStream.Read(mem.GetBuffer(), 0, (int)file.ContentLength);
                ExcelPackage package = new ExcelPackage(mem);
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                myLabel.Text += " " + worksheet.Name;
            }
