    public class IndexModel<TEntity> : ViewModel
        where TEntity : new()
    {
        public IndexModel()
        {
            Items = new List<MappedViewModel<TEntity>>();
        }
    
        public MappedViewModel<TEntity>TemplateItem { get; set; }
        public List<MappedViewModel<TEntity>> Items { get; set; }
    
        public virtual void MapFromEntityList(IEnumerable<TEntity> entityList)
        {
            Items = Mapper.Map<IEnumerable<TEntity>, List<MappedViewModel<TEntity>>>(entityList);
        }
    
    }
