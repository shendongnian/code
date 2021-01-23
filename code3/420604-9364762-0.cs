    public override List<T> SelectRecords<T>()
    {
       objectCustomer.MergeOption = MergeOption.OverwriteChanges;
       return (from custDetails in objectCustomer.Include("Owner_Lookup")
           .Include("Business_Type_Lookup").Include("Assets").Include("Client")
           select custDetails).ToList();
    }
