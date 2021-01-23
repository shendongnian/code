    class OtherEntityCollection : ICollection<OtherEntity>  
    {
      OtherEntityCollection(Predicate<OtherEntity> validation)
      {
        _validator = validator;
      } 
      private List<OtherEntity> _list = new List<OtherEntity>();
      private Predicate<OtherEntity> _validator;
      public override void Add(OtherEntity entity)   
      {
         // Validation logic
         if(_validator(entity))
           _list.Add(entity);   
      }
    }
