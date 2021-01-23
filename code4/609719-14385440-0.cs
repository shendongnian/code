    using AutoMapper;
     
    ...
    Mapper.CreateMap<DataModel.B, ReplyObjects.B>;
    Mapper.CreateMap<DataModel.C, ReplyObjects.C>;
    ...
    return new A
    {
      B = Mapper.Map<DataModel.B, ReplyObjects.B>(varContainingDataForB),
      C = Mapper.Map<DataModel.C, ReplyObjects.C>(varContainingDataForC)
      ...
    };
