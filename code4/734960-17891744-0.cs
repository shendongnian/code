    class DataGridForm {}
    class DataGridForm<TData, TGrid> : DataGridForm {}
    class GridConfigurator
    {
        public DataGridForm DataGrid { get; private set; }
        public DataGridForm<TData, TGrid> GridConfig<TData, TGrid>() where TData : class
        {
            return DataGrid = new DataGridForm<TData, TGrid>();
        }
    }
