        public void LoadEntities(QueryBuilder<Device> query, Action<ServiceLoadResult<Device>> callback, object state)
        {
        
        ((InvokeOperation<List<DivisionHierarchy>>)this.Context.GetAllDivisions()).Completed += (sender, e) =>
            {
                 try
                 {
                     if (sender is InvokeOperation<List<DivisionHierarchy>>)
                     {
                         ObservableCollection<DivisionHierarchy> divisions =
                             new ObservableCollection<DivisionHierarchy>((sender as InvokeOperation<List<DivisionHierarchy>>).Value);
                      }
                  }
                  catch
                  {
                  }
             };         
    }
