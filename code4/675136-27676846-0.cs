    public class MyViewVM : IRequireViewIdentification
    {
        private Guid _viewId;
    
        public Guid ViewID
        {
            get { return _viewId; }
        }
    
        public MyViewVM()
        {
            _viewId = Guid.NewGuid();
        }
    }
