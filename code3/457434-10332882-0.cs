    public XmlPanelRepository()
        {
            public event EventHandler TraceEventHandler;
    
            var panelCom = new PanelCom(); // this is a COM object that connects to a device
    
            // when something happens in the COM object it reports it.
            panelCom.Trace += panelCom_Trace; 
    
        // I want to bubble the trace events up to my UI.
            TraceEventHandler += TraceEventHandler_Tracing;
        }
    
        private void TraceEventHandler_Tracing(object sender, EventArgs e)
        {
            if (TraceEventHandler != null)
            {
                  TraceEventHandler(this, e);
            }
        }
