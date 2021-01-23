    public FilterModel(){
      workList = new List<WorkModel>();
      for(int i = 0; i < MAX_WORKMODEL_COUNT; i++){
        workList.Add(new WorkModel());
      }
    }
