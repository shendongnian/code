    SessionStateHandler tAction = oS =>
            {
                Monitor.Enter(oAllSessions);
                oAllSessions.Add(oS);
                Monitor.Exit(oAllSessions);
            };
