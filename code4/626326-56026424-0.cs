         //path to store Excel file temporarily
         string tempPathExcelFile = AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.Hour + DateTime.Now.Minute +
                              DateTime.Now.Second + DateTime.Now.Millisecond +
                              "_temp";
            try
            {
                //Get Excel using  Microsoft.Office.Interop.Excel;
                Excel.Workbook workbook = ExportDataSetToExcel();
                workbook.SaveAs(tempPathExcelFile, workbook.FileFormat);
                tempPathExcelFile = workbook.FullName;
                workbook.Close();
                byte[] fileBook = File.ReadAllBytes(tempPathExcelFile);
                MemoryStream stream = new MemoryStream();
                string excelBase64String = Convert.ToBase64String(fileBook);
                StreamWriter excelWriter = new StreamWriter(stream);
                excelWriter.Write(excelBase64String);
                excelWriter.Flush();
                stream.Position = 0;
                HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
                httpResponseMessage.Content = new StreamContent(stream);
                httpResponseMessage.Content.Headers.Add("x-filename", "ExcelReport.xlsx");
                httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
                httpResponseMessage.Content.Headers.ContentDisposition =
                    new ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = "ExcelReport.xlsx";
                httpResponseMessage.StatusCode = HttpStatusCode.OK;
                return httpResponseMessage;
            }
            catch (Exception ex)
            {
                _logger.ErrorException(errorMessage, ex);
                return ReturnError(ErrorType.Error, errorMessage);
            }
            finally
            {
                if (File.Exists(tempPathExcelFile))
                {
                    File.Delete(tempPathExcelFile);
                }
            }
          //Javascript Code
          $.ajax({
                        url:  "/api/exportReport",
                        type: 'GET',
                        headers: {
                            Accept: "application/vnd.ms-excel; base64",
                        },
                        success: function (data) {   
                            var uri = 'data:application/vnd.ms-excel;base64,' + data;
                            var link = document.createElement("a");    
                            link.href = uri;
                            link.style = "visibility:hidden";
                            link.download = "ExcelReport.xlsx";
                            document.body.appendChild(link);
                            link.click();
                            document.body.removeChild(link);                        
                        },
                        error: function () {
                            console.log('error Occured while Downloading CSV file.');
                        },
                    }); 
        In the end create an empty anchor tag at the end of your html file. <a></a>
