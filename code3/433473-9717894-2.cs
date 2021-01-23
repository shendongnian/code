        private string m_printerName;
        private string m_server;
        private string m_path;
        private string m_name;
        private Dictionary<string, string> m_parameters;
        private SizeF m_pageSize;
        private float m_marginLeft;
        private float m_marginTop;
        private float m_marginRight;
        private float m_marginBottom;
        private short m_copies;
        private int m_currentPageIndex;
        private List<Stream> m_reportStreams;
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
        private class ReportViewerDisposer : IDisposable
        { 
            // Fields  
            private bool _CollectGarbageOnDispose = true;
            private ReportViewer _ReportViewer;
            private bool disposedValue = false;
            private const string EVENTHANDLER_ON_USER_PREFERENCE_CHANGED = "OnUserPreferenceChanged";
            private const string LIST_HANDLERS = "_handlers";
            private const string ON_USER_PREFERENCE_CHANGED_EVENT = "OnUserPreferenceChangedEvent";
            private const string SYSTEM_EVENT_INVOKE_INFO = "SystemEventInvokeInfo";
            private const string TARGET_DELEGATE = "_delegate";
            private const string TOOLSTRIP_CONTROL_NAME = "reportToolBar";
            private const string TOOLSTRIP_TEXTBOX_CONTROL_NAME_CURRENT_PAGE = "currentPage";
            private const string TOOLSTRIP_TEXTBOX_CONTROL_NAME_TEXT_TO_FIND = "textToFind";
            // Methods  
            public ReportViewerDisposer(ReportViewer rptv)
            {
                if (rptv == null)
                {
                    throw new ArgumentNullException("ReportViewer cannot be null.");
                }
                this._ReportViewer = rptv;
            }
            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposedValue && disposing)
                {
                    this.TearDownReportViewer();
                    this._ReportViewer.Dispose();
                    if (this._CollectGarbageOnDispose)
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        GC.Collect();
                    }
                }
                this.disposedValue = true;
            }
            private void NullRefOnUserPreferenceChanged(object o, string field)
            {
                try
                {
                    FieldInfo fi = o.GetType().GetField(field, BindingFlags.NonPublic | BindingFlags.Instance);
                    if (fi != null)
                    {
                        int i;
                        ToolStripTextBox tb = (ToolStripTextBox)fi.GetValue(o);
                        object tbc = tb.Control;
                        Delegate d = Delegate.CreateDelegate(typeof(UserPreferenceChangedEventHandler), tbc, EVENTHANDLER_ON_USER_PREFERENCE_CHANGED);
                        object handlers = typeof(SystemEvents).GetField(LIST_HANDLERS, BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
                        object upcHandler = typeof(SystemEvents).GetField(ON_USER_PREFERENCE_CHANGED_EVENT, BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
                        object systemEventInvokeInfo = typeof(SystemEvents).GetNestedType(SYSTEM_EVENT_INVOKE_INFO, BindingFlags.NonPublic | BindingFlags.Instance);
                        IList upcHandlerList = (IList)((IDictionary)handlers)[upcHandler];
                        int targetCount = 0;
                        for (i = 0; i < upcHandlerList.Count; i++)
                        {
                            systemEventInvokeInfo = upcHandlerList[i];
                            Delegate target = (Delegate)systemEventInvokeInfo.GetType().GetField(TARGET_DELEGATE, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(systemEventInvokeInfo);
                            if (target.Target == d.Target)
                            {
                                targetCount++;
                            }
                        }
                        for (i = 1; i <= targetCount; i++)
                        {
                            SystemEvents.UserPreferenceChanged -= ((UserPreferenceChangedEventHandler)d);
                        }
                    }
                }
                catch
                {
                }
            } 
            private void TearDownReportViewer()
            {
                FieldInfo fi = this._ReportViewer.GetType().GetField(TOOLSTRIP_CONTROL_NAME, BindingFlags.NonPublic | BindingFlags.Instance);
                if (fi != null)
                {
                    object o = fi.GetValue(this._ReportViewer);
                    this.NullRefOnUserPreferenceChanged(o, TOOLSTRIP_TEXTBOX_CONTROL_NAME_CURRENT_PAGE);
                    this.NullRefOnUserPreferenceChanged(o, TOOLSTRIP_TEXTBOX_CONTROL_NAME_TEXT_TO_FIND);
                }
            }
            // Properties  
            public bool CollectGarbageOnDispose
            {
                get
                {
                    return this._CollectGarbageOnDispose;
                }
                set
                {
                    this._CollectGarbageOnDispose = value;
                }
            }
        } 
