    public TDest Map<TSource, TDest>(TSource ViewModel)
    {
        Mapper.CreateMap<TSource, TDest>();
        TDest result = Mapper.Map<TSource, TDest>(ViewModel;
    }
    
    public ActionResult MyAction(WorkLoadRationViewModel ViewModel)
    {
        WorkLoadRatio model = Map<WorkLoadRationViewModel, WorkLoadRatio>(ViewModel);
    }
