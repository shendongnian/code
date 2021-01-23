    from template in RateTemplates
    where
       template.Policies.Any(p => 
          Staging_history.Changes.Any(c => 
             (c.Policies.Any(cp => cp.PolicyID == p.PolicyID) || 
             c.PolicyFees.Any(cpf => cpf.PolicyID == p.PolicyID) || 
             c.PolicyOptions.Any(cpo => cpo.PolicyID == p.PolicyID)) &&
             c.ChangeTime > new DateTime(2012, 1, 11)
          )
       )
    select new
    {
       TemplateID  = template.ID,
       UserID      = template.UserID,
       PropertyIDs = template.Properties.Select(ppty => ppty.PropertyID)
    }
