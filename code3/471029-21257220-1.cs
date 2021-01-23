    public class AssociatedFilterAttribute : Attribute
    {
        public AssociatedFilterAttribute(Type filterType)
        {
            FilterType = filterType;
        }
        public Type FilterType { get; set; }
    }
