    public class InvokeProxy<T> : MarshalRefByObject where T : class
    {
        public InvokeProxy(T face)
        {
            this.Face = face;
        }
    
        private T Face { get; set; }
    
        public string Execute(string data)
        {
            return this.Face.Execute(data)
        }
    }
