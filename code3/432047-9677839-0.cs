    public void RejectChanges()
    {
         DomainContext.RejectChanges();
         RaisePropertyChangeOnAll();
    }
