    static class GridConfigurator
    {
      public static DataGridForm<TData,TGrid> GridConfig<TData, TGrid>(...) where TData: class
      {
        var grid = new DataGridForm<TData,TGrid>();
        // do something with the parameters to this method to initialize the instance.
         return grid;
      }
    }
