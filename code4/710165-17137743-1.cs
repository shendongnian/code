    public class InvalidNumberException : System.Exception
    {
        public InvalidNumberException() : base() { }
        public InvalidNumberException(string message) : base(message) { }
        public InvalidNumberException(string message, int number) : this(message, null, number) { }
        public InvalidNumberException(string message, System.Exception inner) : base(message, inner) { }
        public InvalidNumberException(string message, System.Exception inner, int number) : base(message, inner)
        {
            this.Number = number;
        }
        public int Number { get; set; }
    }
