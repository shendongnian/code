        public class GlobalClass
        {
            public GlobalClass(BaseClass data)
            {
                var dataType = data == null ? null : data.GetType();
                // do something with the type
            }
        }
        public class Channels : GlobalClass
        {
            public Channels(Channel data) : base(data)
            {
            }
            public class Channel : BaseClass
            {
            }
        }
