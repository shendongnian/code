    PopulateRavenInMemory();
    DatabaseCommands.PutIndex("MultipleAddresses",	
    	new IndexDefinitionBuilder<Agency>
    {
    	Map = agencies => from a in agencies
    					where a.Addresses.Count() > 1
    					select new {}
    });
    Query<Agency>("MultipleAddresses").Customize(x => x.WaitForNonStaleResultsAsOfNow()).Dump();
