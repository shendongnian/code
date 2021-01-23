        protected void prog_Load(object sender, EventArgs e)
		{
            boolean setupComplete = false;
            try // setting an Event log entry, just to see if we can
            {
                logEvent = "prog started";
                EventLog.WriteEntry(logSource, logEvent, EventLogEntryType.Information, 0);
                setupComplete = true;
            }
            catch (Exception eLog1) // we can't, so try to fix
            {
                try
                {
                    EventLog.CreateEventSource(logSource, logLog);
                    logEvent = "prog registered for Event Logging";
                    EventLog.WriteEntry(logSource, logEvent, EventLogEntryType.Information, 0);
                }
                catch (Exception eLog2) // aha!  we probably lack admin rights to set the registry key
                {
                    MessageBox.Show("prog needs admin rights the first time it runs", "prog Setup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
            // run
            if (setupComplete == true)
            {
                DoTheWork();
            }
            
            // exit
            this.Close();
		}
