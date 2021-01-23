        public ActionResult DownloadFile()
        {
            var report = Utilities.Utilities.CreateExcelToPdfReport(
                filePath: Server.MapPath("~/App_Data/Financial Sample.xlsx"),
                excelWorksheet: "Sheet1");
            Utilities.TestUtils.VerifyPdfFileIsReadable(report.FileName);
            string filename = Path.GetFileName(report.FileName);
            string filepath = report.FileName;
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);
            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filename,
                Inline = true,
            };
            Response.AppendHeader("Content-Disposition", cd.ToString());
            return File(filedata, contentType);
        }
