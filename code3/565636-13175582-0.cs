    private void SetReportDataSource(string sCarrierID)
        {
            try
            {
                CrystalReport objCrystalReport = new CrystalReport();
    
                //ReportDocument objReportDoc = new ReportDocument();
    
                ConnectionInfo objConnInfo = new ConnectionInfo();
    
                //string strConn = System.Configuration.ConfigurationSettings.AppSettings[Campaign];
    
                string[] strArray = objCrystalReport.GetCampaignConn();
    
                CrystalDecisions.Shared.TableLogOnInfo logOnInfo = new CrystalDecisions.Shared.TableLogOnInfo();
    
                objConnInfo.DatabaseName = strArray[1].ToString();
                objConnInfo.UserID = strArray[2].ToString();
                objConnInfo.Password = strArray[3].ToString();
                objConnInfo.ServerName = strArray[0].ToString();
    
                String ReportPath = (Server.MapPath("Report") + @"\rptInvoice.rpt");
    
                //String ReportPath = Server.MapPath("~//Report//VendorRegistration.rpt");
    
    
                //objReportDoc = objCrystalReport.CrystalLogon(ReportPath, objConnInfo, ref logOnInfo);
    
    
    
                //// for displaying Crystal report
    
                //crVendorRegistration.ReportSource = objReportDoc;
    
                //crVendorRegistration.ParameterFieldInfo[0].CurrentValues.Clear();
    
    
                ParameterDiscreteValue pdvalue = new ParameterDiscreteValue();
    
    
                pdvalue.Value = Convert.ToInt32(sCarrierID);
    
    
                //crVendorRegistration.ParameterFieldInfo[0].CurrentValues.Add(pdvalue);
    
                //crVendorRegistration.DataBind();
    
    
                //// for Exporitng in PDF
                ReportDocument repDoc = objCrystalReport.CrystalLogon(ReportPath, objConnInfo, ref logOnInfo);
    
                repDoc.ParameterFields[0].CurrentValues.Add(pdvalue);
    
    
    
    
                // Stop buffering the response
                HttpContext.Current.Response.Buffer = false;
                // Clear the response content and headers
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ClearHeaders();
    
                // Export the Report to Response stream in PDF format and file name Customers
                //repDoc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "Truck Invoice " + sCarrierID + "");
                //repDoc.GenerateReport
    
    
                String ReportGenerated = (Server.MapPath("GenerateReport") + @"\rptInvoice" + sCarrierID + ".pdf");
                // There are other format options available such as Word, Excel, CVS, and HTML in the ExportFormatType Enum given by crystal reports
    
                ExportOptions CrExportOptions = new ExportOptions();
    
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
    
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
    
                CrDiskFileDestinationOptions.DiskFileName = ReportGenerated;
    
                CrExportOptions = repDoc.ExportOptions;
    
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
    
                CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
    
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
    
                CrExportOptions.FormatOptions = CrFormatTypeOptions;
    
                repDoc.Export(CrExportOptions);
    
                //pdvalue = new ParameterDiscreteValue();
    
                //pdvalue.Value = QC_By;
    
                //crSalesRpt.ParameterFieldInfo[1].CurrentValues.Add(pdvalue);
    
                //objReportDoc.VerifyDatabase();
                //objReportDoc.Refresh();
            }
            catch (Exception ex)
            {
                //bool rethrow = ExceptionPolicy.HandleException(ex, "");
    
                //if (rethrow)
                //    throw;
    
                //Redirecting to error message page
                //Server.Transfer(ConstantClass.StrErrorPageURL);
            }
        }
