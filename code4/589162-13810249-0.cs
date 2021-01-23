    public class Poco
    {
        private PSHostUserInterface _ui;
        public Poco()
        {
            var runspace = Runspace.DefaultRunspace;
            Pipeline pipeline = runspace.CreateNestedPipeline("Get-Variable host -ValueOnly", false);
            Collection<PSObject> results = pipeline.Invoke();
            if (results.Count > 0)
            {
                var host = results[0].BaseObject as PSHost;
                if (host != null)
                {
                    _ui = host.UI;
                }
            }            
        }
        public void WriteLine(string msg)
        {
            _ui.WriteLine(msg);
        }
    }
