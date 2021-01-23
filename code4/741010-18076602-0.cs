    public void RefreshLogs(string message = "")
        {
            StringBuilder text = new StringBuilder();
            if (string.IsNullOrEmpty(message))
            {
                if (Logger.GetLogs() != null)
                {
                    Logger.GetLogs().ForEach(b =>
                    {
                        text.AppendFormat("{2}{0}:  {1}{2}", b.UserTargetOperation, b.UserEventDate.ToString(), Environment.NewLine);
                        foreach (KeyValuePair<string, string> pair in b.Parameters)
                        {
                            text.AppendFormat("         {0} : {1}{2}", pair.Key, pair.Value, Environment.NewLine);
                        }
                    });
                }
                
                LogEvents.VerticalScrollBarVisibility = ScrollBarVisibility.Auto; // added
                LogEvents.Text = text.ToString();
            }
            else
            {
                **LogEvents.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;** // added
                LogEvents.Text = message;
                LogEvents.TextWrapping = TextWrapping.Wrap;
            }
        }
    }
 
