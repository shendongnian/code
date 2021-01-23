            const string OnLoadFired = "OnLoadFired";
            const string OnShownFired = "OnShownFired";
            List<string> eventsFired = new List<string>();
    
            protected override void OnLoad(EventArgs e)
            {
                if(!eventsFired.Contains(OnLoadFired))
                {
                    eventsFired.Add(OnLoadFired);
                }
                base.OnLoad(e);
            }
    
            public bool IsEventFired(string eventName)
            {
                return eventsFired.Contains(eventName);
            }
