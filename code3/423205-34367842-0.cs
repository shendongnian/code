	public void UpdateCompanyManagement(Company company, int mgmtID)
	{
		var management = company.Managements.Where(m => m.M_ID == mgmtID).SingleOrDefault();
			management.name = "new name";
			management.position = "new position";
			// edit all you want, then save
			// no further code is required
			// except you've done something wrong somewhere
	
		try
		{
			entities.SaveChanges();
		}
		catch (OptimisticConcurrencyException)
		{
			entities.Refresh(RefreshMode.ClientWins, company);
			entities.SaveChanges();
		}
	}
