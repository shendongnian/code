    public static List<TModel> ToModel<TModel>(this List<IEntity> entityList)
        where TModel : IBaseViewModel
    {
        return (List<TModel>)Mapper.Map(entityList, entityList.GetType(), typeof(List<TModel>));
    }
