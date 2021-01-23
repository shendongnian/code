    AutoMapper.Map<DomainModel, ViewModelWithCollection>();
    AutoMapper.Map<EFEntity, object>()
        .Include<EFEntity, ViewModel>();
    
    AutoMapper.Map<EFEntity, ViewModel>();
