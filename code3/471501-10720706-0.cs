    public class InvokeProxy<T> : MarshalRefByObject, IFace where T : IFace
    {
        public InvokeProxy(T face)
        {
            this.Face = face;
        }
        private T Face { get; set; }
        public string Execute(string data)
        {
            return this.Face.Execute(data);
        }
    }
