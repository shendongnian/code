    class OtherEntityCollection : ICollection<OtherEntity>  
    {
    
      private List<OtherEntity> _list = new List<OtherEntity>();
    
      public override void Add(OtherEntity entity)   
      {
         // Validation logic here
         if(valid)
           _list.Add(entity);   
      }
    }
