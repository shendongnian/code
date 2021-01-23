        public class ATestDataContext : DataContext
        {
            public ATestDataContext(string connectionString) : base(connectionString)
            {
            }
            public Table<FTable> FirstTable
            {
                get
                {
                    return this.GetTable<FTable>();
                }
            }
            public Table<STable> SecondTable
            {
                get
                {
                    return this.GetTable<STable>();
                }
            }
        }
    [Table]
    public class FTable : INotifyPropertyChanged, INotifyPropertyChanging
    {...}
    [Table]
    public class STable : INotifyPropertyChanged, INotifyPropertyChanging
    {...}
