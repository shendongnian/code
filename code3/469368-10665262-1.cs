    Mapper.CreateMap<Item, ItemModel>();
    /* Create a mapping from Source to Destination, but map the nested property from 
       the source itself */
    Mapper.CreateMap<SourceModel, DestinationModel>()
        .ForMember(dest => dest.DestinationNestedViewModel, opt => opt.MapFrom(src => src));
    /* Then also create a mapping from Source to DestinationNestedViewModel: */
    Mapper.CreateMap<SourceModel, DestinationNestedViewModel>()
        .ForMember(dest => dest.NestedList, opt => opt.MapFrom(src => src.SourceList));
