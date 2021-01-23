	public IEnumerable<Company> GetAllCompaniesList()
	{
		dynamic primary;
	    var allData = database.Companies.All()
	        .Join(database.Accounts.As("PrimaryAccounts"), out primary)
                .On(primary.Id == database.Companies.Primary)
	        .Join(database.Accounts)
                .On(database.Accounts.CompanyId == database.Companies.Id)
	        .ToList<Company>();
	    return allData;
	}
