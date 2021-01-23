       void JumpsRequest_UpdatedResults(object sender, EventArgs e)
        {
            foreach (int item in JumpsRequest.JumpsBySolarSystemID.Keys)
            {
                if (SolarSystemsByID.ContainsKey(item))
                {
                    SolarSystemsByID[item].Jumps = JumpsRequest.JumpsBySolarSystemID[item];
                }
                else
                {
                    SolarSystemsByID.Add(item, new SolarSystem(JumpsRequest.JumpsBySolarSystemID[item], new HelperClasses.KillsHelperClass()));
                }
            }
        }
