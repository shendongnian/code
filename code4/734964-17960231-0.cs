        class GridConfigurator<TData, TGrid>
           where TData : class
        {
            public DataGridForm<TData, TGrid> DataGrid { get; private set; }
            public DataGridForm<TData, TGrid> GridConfig<TData, TGrid>()
            {
                return DataGrid = new DataGridForm<TData, TGrid>();
            }
        }
