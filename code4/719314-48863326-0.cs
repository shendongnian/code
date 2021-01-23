                             //show Print Dialog
                              PrintDialog printDialog = new PrintDialog();
                              DialogResult dr = printDialog.ShowDialog();
                              if (dr == DialogResult.OK)
                              {
                                        ReportDocument crReportDocument = (ReportDocument)CrystalReportViewer1.ReportSource;
                                       System.Drawing.Printing.PrintDocument printDocument1 = new System.Drawing.Printing.PrintDocument();
                                        //Get the Copy times
                                        int nCopy = printDocument1.PrinterSettings.Copies;
                                        //Get the number of Start Page
                                        int sPage = printDocument1.PrinterSettings.FromPage;
                                        //Get the number of End Page
                                        int ePage = printDocument1.PrinterSettings.ToPage;
                                        crReportDocument.PrintOptions.PrinterName =printDocument1.PrinterSettings.PrinterName;
                                        //Start the printing process.  Provide details of the print job
                                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);
