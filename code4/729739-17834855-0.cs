    class CustomException : Exception {
        public CustomException(dynamic json)
            : base("Plep") {
                _Message = json.message;
        }
        public override string Message {
            get { return _Message; }
        }
        private string _Message;
    }
    class Program {
        static void Main(string[] args) {
            try {
                throw new CustomException(new { message = "Show this message" });
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
