    interface IEntity1 : IEntityBase {}
    interface IEntity2 : IEntityBase {}
    interface IRepositoryBase<TEntity> where TEntity : class, IEntityBase {}
    class Repository1 : RepositoryBase<IEntity1> {}
    class Repository2 : RepositoryBase<IEntity2> {}
    class Repository12 : IRepositoryBase<IEntity1>, IRepositoryBase<IEntity2> {}
    public abstract class RepositoryControllerBase<TRepository, TEntity> 
        where TRepository : RepositoryBase<TEntity>
        where TEntity : IEntityBase {}
    class Controller1 : RepositoryControllerBase<Repository1, Entity1>
    class Controller2 : RepositoryControllerBase<Repository2, Entity2>
    class Controller12 : RepositoryControllerBase<Repository12, Entity1>
