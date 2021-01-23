        public Task Invoke(IDictionary<string, object> environment)
        {
            object value = "";
            //Check if the OWIN key is present
            if (environment.ContainsKey("owin.RequestPath"))
            {
                //Get the value of the key
                environment.TryGetValue("owin.RequestPath", out value);
                //This will block all signalr request, but we can configure according to requirements
                if (value.ToString().Contains("/signalr"))
                {
                    // Tell NewRelic to ignore this particular transaction
                    NewRelic.Api.Agent.NewRelic.IgnoreTransaction();
                    NewRelic.Api.Agent.NewRelic.IgnoreApdex();
                }
            }
            return _nextAppFunc(environment);
        }
