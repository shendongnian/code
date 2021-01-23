        [Export(typeof(Handler))]
        public class HandlerUser : Handler
        {
            public string Name { get; set; }
            public HandlerUser() : base()
            {
            }
        }
