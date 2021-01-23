    public class Client : ClientBase<IMath>
    {
        private static Binding MyBinding { get; set; }
        private static EndpointAddress MyEndpoint { get; set; }
        public Client() : base(MyBinding, MyEndpoint)
        {
        }
        public double Add(double a, double b)
        {
            Open();
            var c = Channel.Add(a, b);
            Close();
            return c;
        }
    }
