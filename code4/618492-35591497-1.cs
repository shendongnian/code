    public class Base
    {
        public int BaseField;
        
        /// <summary>
        /// Apply the state of the passed object to this object.       
        /// </summary>
        public virtual void ApplyState(Base obj)
        {
            BaseField = obj.BaseField;
        }
    }
    
    public class Derived : Base
    {
        public int DerivedField;
        
        public override void ApplyState(Base obj)
        {
            var src = (Derived)srcObj;
            
            if (src != null)
            {
                DerivedField = src.DerivedField;
            }
            
            base.ApplyState(srcObj);        
        }
    }
