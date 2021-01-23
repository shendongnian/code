    private IEnumerable<PublicationViewModel> GetPublicationItems(
        Expression<Func<Publication, bool>> pubQuery)
    {
        return Session.Query<Publication>()
            .Where(pubQuery)                
            .OrderByDescending(p => p.DateApproved)                        
            .Take(10)
            .Select(p => new PublicationViewModel
            {
                ...
            });                
    }
