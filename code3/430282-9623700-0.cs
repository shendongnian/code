    return Session.Query<Publication>()
           .Where(p => p.PublicationType == publicationType)
           .OrderByDescending(p => p.DateApproved)                        
           .Take(10)
           .Select(p => new PublicationViewModel
           {
               ...
           });
