               Encoding csvEncoding = Encoding.UTF8;
                       //byte[] csvFile = GetCSVFileContent(FileUpload1.PostedFile.FileName);
              byte[] csvFile = GetCSVFileContent("Your_CSV_File_NAme");
    
            string attachment = String.Format("attachment; filename={0}.csv", "uomEncoded");
    
            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            Response.ContentType = "text/csv";
            Response.ContentEncoding = csvEncoding;
            Response.AppendHeader("Content-Disposition", attachment);
            //Response.BinaryWrite(csvEncoding.GetPreamble());
            Response.BinaryWrite(csvFile);
            Response.Flush();
            Response.End();
