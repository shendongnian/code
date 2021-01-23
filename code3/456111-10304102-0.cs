        public void GetExcel(string id)
        {
            ExcelPackage p = new ExcelPackage(); 
            //code to add data to the document            
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;  filename=BitlyReport.xlsx");
            MemoryStream stream = new MemoryStream(p.GetAsByteArray());
            Response.OutputStream.Write(stream.ToArray(), 0, stream.ToArray().Length);
            Response.Flush();
            Response.Close();
        }
