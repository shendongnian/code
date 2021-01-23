    List<Company> companyData = (from c in dataContext.Companies select new Company {
      CompanyName = c.CompanyName,
      Address1 = c.Address1,
      Address2 = c.Address2,
      City = c.City,
      State = c.State,
      Country = c.Country,
      Telephone1 = c.Telephone1,
      Telephone2 = c.Telephone2,
      Mobile1 = c.Mobile1,
      Mobile2 = c.Mobile2,
      Email1 = c.Email1,
      Email2 = c.Email2,
      Fax1 = c.Fax1,
      Fax2 = c.Fax2,
      TinNo = c.TinNo,
      IsGroupCompany = c.IsGroupCompany }
      ).ToList(); 
