        //
        // The method is called right before sending headers to the wire*
        // The result is updated internal _WriteBuffer
        //
        // See ClearRequestForResubmit() for the matching cleanup code path.
        // 
        internal void SerializeHeaders() {
        ....
        ....
            string connectionString = HttpKnownHeaderNames.Connection; 
            if (UsesProxySemantics || IsTunnelRequest ) { 
                _HttpRequestHeaders.RemoveInternal(HttpKnownHeaderNames.Connection);
                connectionString = HttpKnownHeaderNames.ProxyConnection; 
                if (!ValidationHelper.IsBlankString(Connection)) {
                    _HttpRequestHeaders.AddInternal(HttpKnownHeaderNames.ProxyConnection, _HttpRequestHeaders[HttpKnownHeaderNames.Connection]);
                }
            } 
            else {
                _HttpRequestHeaders.RemoveInternal(HttpKnownHeaderNames.ProxyConnection); 
            } 
