    return this.Database
    	.SqlQuery<CompanyDto>(sqlQuery).ToList()
    
    	// ConvertAll -> Converts every element in the list to the specified type.
    	.ConvertAll(
    		c => new Company {
    			CompanyType =
    				new CompanyType
    					{
    						Code = c.Code, 
    						Mnemonic = c.Mnemonic, 
    						Description = c.Description, 
    						CompanyLevel = c.CompanyLevelCode, 
    						CompanyPosition = Convert.ToInt32(c.CompanyPosition)
    					}, 
    			Leisure =
    				new Leisure
    					{
    						Code = c.LeisureCode, 
    						Description = c.LeisureDescription, 
    						Minimum = "Y".Equals(c.StateMinimumIndicator, StringComparison.OrdinalIgnoreCase), 
    						Recommended =
    							"Y".Equals(c.RecommendedLeisureIndicator, StringComparison.OrdinalIgnoreCase)
    					}, 
    			Loan =
    				new Loan { Code = c.LoanCode, Description = c.LoanDescription }
    		}
    	)
    	
    	// Convert to lookup list, in other words, add a key.
    	.ToLookup(
    		c =>
    			new Tuple<string, string, string, string, int>(
    				c.CompanyType.Code, 
    				c.CompanyType.Mnemonic, 
    				c.CompanyType.Description, 
    				c.CompanyType.CompanyLevel, 
    				c.CompanyType.CompanyPosition
    			)
    	)
    	
    	// And convert again to another type
    	.Select(
    			t =>
    			new CompanyOption
    				{
    					CompanyType =
    						new CompanyType
    							{
    								Code = t.Key.Item1, 
    								Mnemonic = t.Key.Item2, 
    								Description = t.Key.Item3, 
    								CompanyLevel = t.Key.Item4, 
    								CompanyPosition = t.Key.Item5
    							}, 
    					Leisures =
    						(from Company c in t select c.Leisure).GroupBy(l => l.Code).Select(
    							gr => gr.First()), 
    					Loans =
    						(from Company c in t select c.Loan).GroupBy(d => d.Code).Select(
    							gr => gr.First())
    				}).OrderBy(t => t.CompanyType.CompanyPosition);
