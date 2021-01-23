    var inactives = from am in Aspnet_Memberships
            join mm in Member_members on am.UserId equals mm.Member_guid
        	where mm.Is_active==false && mm.Org_id==1
    		select new{am,mm};
    		//inactives.Take(4).ToArray().Dump();
    		var serialized = JsonConvert.SerializeObject(
                inactives.Skip(1).Select(i => i.mm).First(), 
                new  JsonSerializerSettings()
                {
                    ContractResolver = new DynamicContractResolver(), 
                    PreserveReferencesHandling = PreserveReferencesHandling.None,
                    ReferenceLoopHandling= ReferenceLoopHandling.Ignore
                }); 
                //.Dump();
