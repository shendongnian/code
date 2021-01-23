    private class CustomSponsor : MarshalByRefObject, ISponsor
    {
        public TimeSpan Renewal(ILease lease)
        {
            Debug.Assert(lease.CurrentState == LeaseState.Active);
            //Renew lease by 5 minutes
    
            return TimeSpan.FromMinutes(5);
        }
    }
