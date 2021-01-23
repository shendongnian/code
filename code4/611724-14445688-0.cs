    public class Car
    {
      ...
      Model _model 
    
      public virtual Model Model
      { 
       get { return _model; } 
       set 
       {
         _model = value;
         ModelId = _model.ID;
       } 
      }
    
      public virtual int ModelId { get; set; }
    }
