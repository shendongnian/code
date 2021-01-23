       public void PrintReport()
        {
            string mime, extension;
            
            ReportViewer viewer = new ReportViewer();
            ReportViewerDisposer disposer = new ReportViewerDisposer(viewer);
            try
            {
                viewer.ProcessingMode = ProcessingMode.Remote;
                viewer.ServerReport.ReportServerUrl = new Uri(String.Format("http://{0}/ReportServer", m_server));
                viewer.ServerReport.ReportPath = String.Format("/{0}/{1}", m_path, m_name);
                List<ReportParameter> param = new List<ReportParameter>();
                foreach (ReportParameterInfo paramInfo in viewer.ServerReport.GetParameters())
                {
                    if (m_parameters.ContainsKey(paramInfo.Name.ToUpperInvariant()))
                    {
                        string value = m_parameters[paramInfo.Name.ToUpperInvariant()];
                        param.Add(new ReportParameter(paramInfo.Name, value));
                    }
                }
                viewer.ServerReport.SetParameters(param);
                viewer.RefreshReport();
                CultureInfo us = new CultureInfo("en-US");
                string deviceInfo = String.Format(
                  "<DeviceInfo>" +
                  "  <OutputFormat>EMF</OutputFormat>" +
                  "  <PageWidth>{0}cm</PageWidth>" +
                  "  <PageHeight>{1}cm</PageHeight>" +
                  "  <MarginTop>{2}cm</MarginTop>" +
                  "  <MarginLeft>{3}cm</MarginLeft>" +
                  "  <MarginRight>{4}cm</MarginRight>" +
                  "  <MarginBottom>{5}cm</MarginBottom>" +
                  "</DeviceInfo>",
                  Math.Round(m_pageSize.Width, 2).ToString(us),
                  Math.Round(m_pageSize.Height, 2).ToString(us),
                  Math.Round(m_marginTop, 2).ToString(us),
                  Math.Round(m_marginLeft, 2).ToString(us),
                  Math.Round(m_marginRight, 2).ToString(us),
                  Math.Round(m_marginBottom, 2).ToString(us));
                m_reportStreams = new List<Stream>();
                try
                {
                    NameValueCollection urlAccessParameters = new NameValueCollection();
                    urlAccessParameters.Add("rs:PersistStreams", "True");
                    Stream s = viewer.ServerReport.Render("IMAGE", deviceInfo, urlAccessParameters, out mime, out extension);
                    m_reportStreams.Add(s);
                    urlAccessParameters.Remove("rs:PersistStreams");
                    urlAccessParameters.Add("rs:GetNextStream", "True");
                    do
                    {
                        s = viewer.ServerReport.Render("IMAGE", deviceInfo, urlAccessParameters, out mime, out extension);
                        if (s.Length != 0) m_reportStreams.Add(s);
                    }
                    while (s.Length > 0);
                    DoPrint();
                }
                finally
                {
                    foreach (Stream s in m_reportStreams)
                    {
                        s.Close();
                        s.Dispose();
                    }
                    m_reportStreams = null;
                }
            }
            finally
            {
                disposer.CollectGarbageOnDispose = true;
                disposer.Dispose();
            }
        }
        private void DoPrint()
        {
            m_currentPageIndex = 0;
            PrintDocument printDoc = new PrintDocument();
            try
            {
                printDoc.PrintController = new StandardPrintController();
                printDoc.PrinterSettings.PrinterName = m_printerName;
                printDoc.PrinterSettings.Copies = m_copies;
                if (!printDoc.PrinterSettings.IsValid)
                {
                    throw new ArgumentException(String.Format("Drucker '{0}' ist nicht gültig!", m_printerName));
                }
                // Drucke das Dokument aus
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                printDoc.QueryPageSettings += new QueryPageSettingsEventHandler(QueryPageSettings);
                printDoc.Print();
            }
            finally
            {
                printDoc.PrintPage -= new PrintPageEventHandler(PrintPage);
                printDoc.QueryPageSettings -= new QueryPageSettingsEventHandler(QueryPageSettings);
                printDoc.Dispose();
            }
        }
