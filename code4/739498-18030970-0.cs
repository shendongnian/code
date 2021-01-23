    return (from c in _dc.Contact 
                  join co in _dc.Company on c.CompanyId equals co.CompanyId into subCompanies
                    from sc in subCompanies.DefaultIfEmpty()
                    where c.ContactId == id
                    select new ContactDto
                    {
                        ContactId = c.ContactId,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Company = sc
                    }).FirstOrDefault()
