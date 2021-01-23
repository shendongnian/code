    public void abcd()
            {
                try
                {
                    string UniqueNumber = Request.QueryString["UniqueNumber"];
                    string strFileName = UniqueNumber;
                    string strFileExtension = ".pdf";
                    string strContentType = FileManager.FileContentType_application_pdf;
                    string strExportData = string.Empty;
                    Document pdfDoc = new Document();
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    var output = new MemoryStream();
                    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.Cambria, BaseFont.CP1252, false);
                    //Font ChronicleFont = new Font(bfTimes, 26f);
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter htw = new HtmlTextWriter(sw);
                    StringReader sr;
                    sr = new StringReader(Convert.ToString(ExportData.UserDetails(UniqueNumber)));
                    PdfWriter.GetInstance(pdfDoc, output);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    strFileName = strFileName.Replace(" - ", "-").Replace(" ", "-").Replace("--", "-");
                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}{1}", strFileName, strFileExtension));
                    Response.ContentType = strContentType;
                    Response.Charset = "";
                    Response.BinaryWrite(output.ToArray());
                    Response.Flush();
                    Response.End();
    
                }
                catch (Exception ex)
                {
                    //
    
                }
            }
