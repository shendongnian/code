    public class OsVersion
    {
        public static Task<string> GetAsync()
        {
            var t = new TaskCompletionSource<string>();
            var w = new WebView();
            w.AllowedScriptNotifyUris = WebView.AnyScriptNotifyUri;
            w.NavigateToString("<html />");
            NotifyEventHandler h = null;
            h = (s, e) =>
            {
                try
                {
                    var match = Regex.Match(e.Value, @"Windows\s+NT\s+\d+(\.\d+)?");
                    if (match.Success)
                        t.SetResult(match.Value);
                    else
                        t.SetResult("Unknowm");
                }
                catch (Exception ex) { t.SetException(ex); }
                finally { /* release */ w.ScriptNotify -= h; }
            };
            w.ScriptNotify += h;
            w.InvokeScript("execScript", new[] { "window.external.notify(navigator.appVersion); " });
            return t.Task;
        }
