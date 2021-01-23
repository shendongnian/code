        public FileContentResult GetPOReport(DataTable reportData, int poNumber, string copies, out string fileName, out string downloadPath)
        {
            fileName = "PO_" + poNumber.ToString().Trim() + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".pdf";
            downloadPath = "/Generated/" + fileName;
            var outputFiles = new Dictionary<string, string>
                                  {
                                      {"", Server.MapPath("~" + downloadPath)}
                                  };
            if (!string.IsNullOrWhiteSpace(copies))
            {
                var copyList = copies.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var temp in copyList)
                    outputFiles.Add(temp, Server.MapPath("~" + "/Generated/" + temp.Trim() + ".pdf"));
            }
            FileContentResult returnFile = null;
            foreach (var outputFile in outputFiles)
            {
                var file = WriteReportToDisk(reportData, outputFile.Value, outputFile.Key);
                if (file == null)
                    continue;
                if (string.IsNullOrWhiteSpace(outputFile.Key))
                    returnFile = file;
                else
                    PrintReport(outputFile.Value);
            }
            return returnFile;
        }
        public void PrintReport(string filePath)
        {
            try
            {
                if (!ConfigurationManager.AppSettings.AllKeys.Contains("AdobeReaderPath") ||
                    !ConfigurationManager.AppSettings.AllKeys.Contains("AdobePrintParameters") ||
                    !ConfigurationManager.AppSettings.AllKeys.Contains("PrinterName"))
                    return;
                var adobeReaderPath = ConfigurationManager.AppSettings["AdobeReaderPath"].Trim();
                var adobePrintParameters = ConfigurationManager.AppSettings["AdobePrintParameters"].Trim();
                var printerName = ConfigurationManager.AppSettings["PrinterName"].Trim();
                var printProcessDomain = ConfigurationManager.AppSettings["PrintProcessDomain"].Trim();
                var printProcessUserName = ConfigurationManager.AppSettings["PrintProcessUserName"].Trim();
                var printProcessPassword = ConfigurationManager.AppSettings["PrintProcessPassword"].Trim();
                var userPrinter = Entities.UserPrinters.FirstOrDefault(p => p.UserName == User.Identity.Name);
                if (userPrinter != null)
                    printerName = userPrinter.PrinterName.Trim();
                using (var process = new Process
                {
                    StartInfo =
                        new ProcessStartInfo(
                        adobeReaderPath,
                        string.Format(adobePrintParameters, filePath, printerName)
                        )
                })
                {
                    if (!string.IsNullOrWhiteSpace(printProcessUserName))
                    {
                        if (!string.IsNullOrWhiteSpace(printProcessDomain))
                            process.StartInfo.Domain = printProcessDomain;
                        process.StartInfo.UserName = printProcessUserName;
                        var securePassword = new SecureString();
                        foreach (var passwordCharacter in printProcessPassword)
                            securePassword.AppendChar(passwordCharacter);
                        process.StartInfo.Password = securePassword;
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = true;
                        process.StartInfo.LoadUserProfile = true;
                    }
                    process.Start();
                    process.WaitForExit(30000);
                }
            }
            catch (Exception exception)
            {
                EventLog.WriteEntry("PO Suggestion Viewer", string.Format("PO Suggestion Viewer Error:\n{0}", exception.Message));
                throw;
            }
        }
        public FileContentResult WriteReportToDisk(DataTable reportData, string filePath, string copy)
        {
            var webReport = new WebReport()
            {
                ExportFileName = "PO Report",
                ReportPath = Server.MapPath("~/Reports/PurchaseOrderReport.rdlc")
            };
            if (!string.IsNullOrWhiteSpace(copy))
                webReport.ReportParameters.Add(new ReportParameter("Copy", copy));
            if ((User != null) && (User.Identity != null) && (User.Identity.Name != null))
                webReport.ReportParameters.Add(new ReportParameter("User", User.Identity.Name));
            webReport.ReportDataSources.Add(new ReportDataSource("ReportData", reportData));
            var report = webReport.GetReport();
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}.{1}", webReport.ExportFileName, webReport.FileNameExtension));
            Response.ContentType = "application/pdf";
            var file = File(report, webReport.MimeType, "POReport");
            System.IO.File.WriteAllBytes(filePath, file.FileContents);
            return file;
        }
