    public TDest Map<TSource, TDest>(TSource viewModel)
    {
        Mapper.CreateMap<TSource, TDest>();
        TDest result = Mapper.Map<TSource, TDest>(viewModel);
        return result;
    }
    
    public ActionResult MyAction(WorkLoadRationViewModel viewModel)
    {
        WorkLoadRatio model = Map<WorkLoadRationViewModel, WorkLoadRatio>(viewModel);
    }
