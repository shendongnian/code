    Task<ProcessorArchitecture> WhatProcessor()
    {
        var t = new TaskCompletionSource<ProcessorArchitecture>();
        var w = new WebView();
        w.AllowedScriptNotifyUris = WebView.AnyScriptNotifyUri;
        w.NavigateToString("<html />");
        NotifyEventHandler h = null;
        h = (s, e) =>
        {
            // http://blogs.msdn.com/b/ie/archive/2012/07/12/ie10-user-agent-string-update.aspx
            // IE10 on Windows RT: Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; ARM; Trident/6.0;)
            // 32-bit IE10 on 64-bit Windows: Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)
            // 64-bit IE10 on 64-bit Windows: Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Win64; x64; Trident/6.0)
            // 32-bit IE10 on 32-bit Windows: Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0) 
            try
            {
                if (e.Value.Contains("ARM;"))
                    t.SetResult(Windows.System.ProcessorArchitecture.Arm);
                else if (e.Value.Contains("WOW64;") || e.Value.Contains("Win64;") || e.Value.Contains("x64;"))
                    t.SetResult(Windows.System.ProcessorArchitecture.X64);
                else
                    t.SetResult(Windows.System.ProcessorArchitecture.X86);
            }
            catch (Exception ex) { t.SetException(ex); }
            finally { /* release */ w.ScriptNotify -= h; }
        };
        w.ScriptNotify += h;
        w.InvokeScript("execScript", new[] { "window.external.notify(navigator.userAgent); " });
        return t.Task;
    }
