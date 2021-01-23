    internal class CustomerWithMultipleStorage
    {
    	private readonly ISqlDataLayer _sqlDataLayer;
    	private readonly ITableStorageDataLayer _tableStorageDataLayer;
        private readonly Lazy<string> _details;
        private string _detailsValue;
        
        public CustomerWithMultipleStorage(ISqlDataLayer sqlDataLayer, ITableStorageDataLayer tableStorageDataLayer)
        {
    		_sqlDataLayer = sqlDataLayer;
    		_tableStorageDataLayer = tableStorageDataLayer;
    		
    		_details = new Lazy<string>(() => return __tableStorageDataLayer.GetValue<Customer>(this, "Details"));
        }
    
        public override string Details
        {
             get
    		 {
    			return (_detailsValue ?? (_detailsValue = _details.Value));
    		 }
             set
             {
    			_detailsValue = value;
    			_tableStorageDataLayer.SetValue<Customer>(this, _detailsValue);
             }
        }
    }
