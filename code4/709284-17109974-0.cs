    private ITextTemplatingEngineHost _host;
    private ITextTemplatingEngineHost HostProperty {
        get
        {
            if (_host == null)
            {
                _host = (ITextTemplatingEngineHost)this.GetType().GetProperty("Host").GetValue(this, null);
            }
            return _host;
        }            
    }
