    public sealed class MyError
    {
        public static readonly MyError OK = new MyError(0, "OK");
        public static readonly MyError Bad = new MyError(1, "Bad Stuff");
        protected MyError(int id, string message)
        {
            this.ID = id;
            this.Message = message;
        }
        public int ID { get; private set; }
        public string Message { get; private set; }
    }
