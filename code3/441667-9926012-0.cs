    public class ConstrainedList<T> : IList<T> where T:ITemplate
    {
        private List<T> _inner = new List<T>();
        Func<T, bool> _constraint;
    
        public ConstrainedList<T>(Func<T, bool> predicate)
        {
           _constraint = predicate;
        }
    
        #Region IList Implementation
     
        public void Add(T item)
        {
            if (_constraint(item))
            {
               _inner.Add(item);
            }
            else
            {
               throw new ArgumentException("Does not meet necessary constraint");
            }
        }
    
        // rest of implementation
        ...
    
        #End Region
    }
    
    var specialList1 = new ConstrainedList<ITemplate>(t => null != t && typeof(TemplateA) == t.GetType());
    var specialList2 = new ConstrainedList<ITemplate>(t => null != t && t.SomeMethod() >= 3);
