    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
    public void AddOrUpdate<T> (T entity) where T : BaseEntity
    {
       if(entity.Id > 0){
          Entry(entity).State = EntityState.Modified;
       }
       else
       {
          Set<T>().Add(entity);
       }
    }
    // 
    var model = Mapper.Map<Record>(record);
    db.AddOrUpdate(model);
    db.SaveChanges();
