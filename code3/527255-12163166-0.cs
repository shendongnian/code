     private void Main_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
            {
                // There will probably be lots of stuff that we'll need to dispose of when closing
                if (servers.Count > 0)
                {
                    foreach (string key in servers.Keys)
                    {
                        try
                        {
                            EventLog el = (EventLog)servers[key];
                            el.Dispose();
                        }
                        catch(Exception ex) 
                        {
                            throw ex;
                        }
                    }
                }
            }
