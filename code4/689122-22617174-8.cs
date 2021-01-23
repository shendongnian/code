    public class Message : IMessage
    {
        public Model.TestResponse Test()
        {
            return new Model.TestResponse() { success = true, message = "OK!" };
        }
    }
