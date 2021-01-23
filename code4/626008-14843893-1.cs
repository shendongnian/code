       void JumpsRequest_UpdatedResults(object sender, EventArgs e)
        {
            foreach (int item in JumpsRequest.JumpsBySolarSystemID.Keys)
            {
                SolarSystem system;
                if (SolarSystemsByID.TryGetValue(item, out system))
                {
                    system.Jumps = JumpsRequest.JumpsBySolarSystemID[item];
                }
                else
                {
                    SolarSystemsByID.Add(item, new SolarSystem(JumpsRequest.JumpsBySolarSystemID[item], new HelperClasses.KillsHelperClass()));
                }
            }
        }
