    public partial class WebStoreDataContext
    {
        partial void OnCreated()
        {
            // writing info into Trace file
            Log = Console.Out;
            Log = new LogLinqToSql();
            SubmitChanges();
        }
    }
