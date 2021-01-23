    try
    {				                    
        /*await Task.WhenAny(SendStatementsAsync(_cts.Token), 
    		   ReadTcpClientAsync(_cts.Token),
    		   ProcessUpdateAsync(_cts.Token, _progress)).ConfigureAwait(false);*/
        Task.Run(() => SendStatementsAsync(_cts.Token)).ConfigureAwait(false);
        Task.Run(() => ReadTcpClientAsync(_cts.Token)).ConfigureAwait(false);
        Task.Run(() => ProcessUpdateAsync(_cts.Token, _progress)).ConfigureAwait(false);
        Trace.WriteLineIf(clientSwitch.TraceInfo, "Worker threads started", "[Client.RunAsync]");
    }
