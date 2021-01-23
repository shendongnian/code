        public interface IHandler
        {
            string Message { get; }
            public void Create(string msg);
        }
        [Export(typeof(Handler))]
        public class HandlerUser : IHandler
        {
            public string Name { get; set; }
            public string Message { get; private set;}
            public HandlerUser() 
            {
            }
            public void Create(string msg)
            {
               this.Message = msg
            }
        }
