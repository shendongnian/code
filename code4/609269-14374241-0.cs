    partial class DALDataContext : System.Data.Linq.DataContext
    {
        partial void OnCreated()
        {
            this.CommandTimeout = 100;
        }
    }
