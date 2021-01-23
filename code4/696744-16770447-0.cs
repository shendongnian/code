     public class Model {
        public List<ModelProperty> Properties { get; set; }
        public string ModelName { get; set; }
        public virtual Type ClsType { get {
               ClsObject.GetType();
        } }
        public object ClsObject { get; protected set; }
    }
    
    public class Model<T> : Model {
         public override Type ClsType { get{
          return typeof(T);
         }}
    
         public T Cls
        {
            get { return (T) ClsObject; }
            set { ClsObject = value; }
        }
    }
