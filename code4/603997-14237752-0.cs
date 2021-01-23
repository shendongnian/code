    foreach (var u in userrecords)
    {
      u.CurrentCompany = u.EmploymentHistories
                          .FirstOrDefault(e => e.IsCurrent && e.MasterCompany != null)
                          .MasterCompany.Description;
                                            
      u.CurrentPosition = u.EmploymentHistories
                           .FirstOrDefault(e => e.IsCurrent && string.IsNullOrEmpty(e.JobTitle))
                           .JobTitle;
    }
