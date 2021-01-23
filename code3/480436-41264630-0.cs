    public partial class GlobalPricingDataContext: System.Data.Linq.DataContext
    {
        public override void SubmitChanges(ConflictMode failureMode)
        {
            int inserts = base.GetChangeSet().Inserts.Count;
            int updates = base.GetChangeSet().Updates.Count;
            int deletes = base.GetChangeSet().Deletes.Count;
    
            Trace.WriteLine(string.Format("{0}  There are {1} inserts, {2} updates and {3} deletes.", DateTime.Now.ToLongTimeString(), inserts, updates, deletes)); 
    
            base.SubmitChanges(failureMode);
        }
    }
