    public class SecureModel<T> : ISecureModel
    {
        public string Info { get; set; }
        public T Data { get; set; }
        object ISecureModel.Data {
            get { return Data; }
        }
    }
