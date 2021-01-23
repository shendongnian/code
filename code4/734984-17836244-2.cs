      public void RegisterDto<TDto>(DtoSelection dtoSelection)
        where TDto : AbstractDto, new()
      {
         Container.Register<AbstractDto,Dto1>(dtoSelection.ToString());
      }
      public TDto GetDto<TDto>(DtoSelection dtoSelection)
        where TDto : AbstractDto
      {
         return Container.Resolve<AbstractDto>(dtoSelection.ToString()) as TDto;
      }
     
