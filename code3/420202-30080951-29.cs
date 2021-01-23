	const string sql = @"SELECT tc.[ContactID] as ContactID
			  ,tc.[ContactName] as ContactName
			  ,tp.[PhoneId] AS TestPhones_PhoneId
			  ,tp.[ContactId] AS TestPhones_ContactId
			  ,tp.[Number] AS TestPhones_Number
			  FROM TestContact tc
		INNER JOIN TestPhone tp ON tc.ContactId = tp.ContactId";
    string connectionString = // -- Insert SQL connection string here.
	using (var conn = new SqlConnection(connectionString))
	{
		conn.Open();	
		{
			// Step 1: Use Dapper to return the  flat result as a Dynamic.
			dynamic test = conn.Query<dynamic>(sql);
			// Step 2: Use Slapper.Automapper for mapping to the POCO Entities.
            // IMPORTANT: Let Slapper.Automapper know how to do the mapping;
            // let it know the primary key for each POCO.
			Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(TestContact), new List<string> { "ContactID" });
			Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(TestPhone), new List<string> { "PhoneID" });
			
			var testContact = (Slapper.AutoMapper.MapDynamic<TestContact>(test) as IEnumerable<TestContact>).ToList();		
			foreach (var c in testContact)
			{								
				foreach (var p in c.TestPhones)
				{
					Console.Write("ContactName: {0}: Phone: {1}\n", c.ContactName, p.Number);	
				}
			}
		}
	}
