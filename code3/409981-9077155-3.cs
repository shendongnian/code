        public class GlobalClass
        {
            public GlobalClass(Type actualType)
            {
                Debug.Assert(typeof(BaseClass).IsAssignableFrom(actualType));
            }
        }
        public class Channels : GlobalClass
        {
            public Channels() : base(typeof(Channel))
            {
            }
            public class Channel : BaseClass
            {
            }
        }
