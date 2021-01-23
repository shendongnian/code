    public static void ConvertUiToDto<TUi, TDto, TEntity>(TUi uiEntity, TDto dtoEntity, DTOEntities.MyProductDTO<TEntity, TDto> dtoEntity2)
        where TDto : DTOEntities.MyProductDTO<TEntity, TDto>
        where TEntity : EntityObject
    {
    }
