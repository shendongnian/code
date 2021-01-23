        public class GlobalClass<T> where T : BaseClass
        {
            public GlobalClass()
            {
                var theType = typeof(T);    //you got it
            }
        }
        public class BaseClass
        {
            public string Title { get; set; }
        }
        public class Channel : BaseClass { }
        public class Channels : GlobalClass<Channel> { }
