    public class OperationContextExtension : IExtension<OperationContext>
    {
        public void Attach(OperationContext owner)
        {
            this.Current = new Dictionary<string, string>();
        }
        public void Detach(OperationContext owner)
        {
            this.Current = null;
        }
        public Dictionary<string,string> Current { get; set; }
    }
