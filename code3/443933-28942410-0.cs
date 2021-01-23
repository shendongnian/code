            StringBuilder logMessage = new StringBuilder();
            logMessage.AppendLine(string.Format(CultureInfo.InvariantCulture, "-------------------[ START - {0} - {1} -------------------]", MethodBase.GetCurrentMethod(), DateTime.Now.ToShortDateString()));
            logMessage.AppendLine(string.Format(CultureInfo.InvariantCulture, "Parameter: 1: [Name - {0}, Value - {1}", "None]", Convert.ToString("")));
            try
            {
                if (string.IsNullOrWhiteSpace(FileName)) return; // Prevents execution of below statements if filename is not selected.
                PrintDocument pd = new PrintDocument();
                //Disable the printing document pop-up dialog shown during printing.
                PrintController printController = new StandardPrintController();
                pd.PrintController = printController;
                //For testing only: Hardcoded set paper size to particular paper.
                //pd.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize("Custom 6x4", 720, 478);
                //pd.DefaultPageSettings.PaperSize = new PaperSize("Custom 6x4", 720, 478);
                pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                pd.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                pd.PrintPage += (sndr, args) =>
                {
                    System.Drawing.Image i = System.Drawing.Image.FromFile(FileName);
                    //Adjust the size of the image to the page to print the full image without loosing any part of the image.
                    System.Drawing.Rectangle m = args.MarginBounds;
                    //Logic below maintains Aspect Ratio.
                    if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
                    {
                        m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
                    }
                    else
                    {
                        m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
                    }
                    //Calculating optimal orientation.
                    pd.DefaultPageSettings.Landscape = m.Width > m.Height;
                    //Putting image in center of page.
                    m.Y = (int)((((System.Drawing.Printing.PrintDocument)(sndr)).DefaultPageSettings.PaperSize.Height - m.Height) / 2);
                    m.X = (int)((((System.Drawing.Printing.PrintDocument)(sndr)).DefaultPageSettings.PaperSize.Width - m.Width) / 2);
                    args.Graphics.DrawImage(i, m);
                };
                pd.Print();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error : {0}\n By : {1}-{2}", ex.ToString(), this.GetType(), MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                logMessage.AppendLine(string.Format(CultureInfo.InvariantCulture, "-------------------[ END  - {0} - {1} -------------------]", MethodBase.GetCurrentMethod().Name, DateTime.Now.ToShortDateString()));
                log.Info(logMessage.ToString());
            }
        }
