    public LogScopeAttribute(string header, string footer)
    {
        _header = header;
        _footer = footer;
        _logScopeInterceptorFactory = Kernel.Get<ILogScopeInterceptorFactory>();
    }
