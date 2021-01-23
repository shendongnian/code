    namespace System
    {
        internal class RuntimeType : Type, ISerializable, ICloneable
        {
            ...
            public override string Name
            {
                get { ... }
            }
        }
    }
