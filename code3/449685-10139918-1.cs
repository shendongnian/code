    return (from c in Context.Companies
    where c.BuySells.Any( b=>b.CategoryId == categoryId)
    	  && c.Products.Any( p=>p.CategoryId == categoryId)
    select new
    {
      c.CompanyId,
      c.CompanyName,
      c.Country.Flag,
      c.Profile,
      c.IsUsingSMSNotifications,
      c.IsVerified,
      c.MembershipType,
      c.RegistrationDate, c.ShortProfile,
    }).Skip(skip).Take(take).ToList();
