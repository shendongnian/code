    public interface IParamDbService<out TEntity> where TEntity : IParam
    {
        IQueryable<TEntity> GetAll();
    }
    IParamDbService<IParam> paramDbService;
    IParamDbService<Param1> param1DbService;
    paramDbService=param1DbService
