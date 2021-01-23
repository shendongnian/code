    HomeDataContext proxy = new HomeDataContext(new Uri(url + "/_vti_bin/listdata.svc"));
    proxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
    PeopleItem person = proxy.People.Where(p => p.Name.Equals(myName)).First();
    PeopleItem boss = proxy.People.Where(p => p.Name.Equals(bossName)).First();
    CompaniesItem company= proxy.Companies.Where(c => c.ID.Equals(companyName)).First();
    //company.Employees.Add(person);
    company.Boss = boss;
    company.Name = "New Name";
    proxy.UpdateObject(company);
    proxy.SaveChanges();
    //To remove employee from company
    proxy.DeleteLink(company, "Employee", person);
    proxy.SaveChanges();
    //To Add person as employee
    proxy.AddLink(company,"Employee",person);
    proxy.SaveChanges();
