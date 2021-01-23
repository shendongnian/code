    private IEnumerable<PublicationViewModel>
        GetPublicationItems(PublicationType type)
    {
        return Session.Query<Publication>()
            .Where(p => p.PublicationType == type)
            .OrderByDescending(p => p.DateApproved)                        
            .Take(10)
            .Select(p => new PublicationViewModel
            {
                ...
            });                
    }
