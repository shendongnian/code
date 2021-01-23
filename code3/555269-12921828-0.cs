        Dictionary<string, DateTime> odict = new Dictionary<string, DateTime>();
        //Liste tous les Clients EMAIL (3)
        foreach(var TheClientID in TheClient.GetClient_Id(3)) {
                Dictionary<string, DateTime> Temp = oEmail.VoirEML(TheClientID.Key);
                //odict = odict.Concat(Temp).ToDictionary(pair => pair.Key, pair => pair.Value);
                foreach(var kvp in Temp){
                        odict[kvp.Key] = kvp.Value;
	        }
        }
