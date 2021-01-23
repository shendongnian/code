    internal void SetManagerIdInternal(string id, object value)
    {
        if(mgr != null)
        {
            mgr.TelemetryValueChanged -= MgrOnTelemetryValueChanged;
            mgr[id] = value;
            mgr.TelemetryValueChanged += MgrOnTelemetryValueChanged;
        }
    }
