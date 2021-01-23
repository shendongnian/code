    public class PrivateDynamicAccessor : DynamicObject
    {
        private readonly object instance;
        public PrivateDynamicAccessor(string typeName)
        {
            // Instantiate here via reflection
        }
        public override bool TryGetMember(GetMemberBinder binder,
                                          out Object result)
        {
            // Access the fields or properties with reflection
        }
    }
