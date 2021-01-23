    public class PlcRepository : SomeBase
    {
        public PlcRepository()
        {
            //Do what you need to do
        }
        /// <summary>
        /// Query the data from your PLC
        /// </summary>
        /// <param name="plcId">The ID of the PLC to query</param>
        /// <returns>PlcData</returns>
        public PlcData GetData(object plcId)
        {
            PlcData data = new PlcData()
            //create instance of your class that is able to talk to the PLC
            
            //Query your plc
            //Fill your dataobject
            //return the dataobject you just filled
            return data;
        }
    }
    public class MainViewModel
    {
        private readonly PlcRepository _plcRepository;
        public MainViewModel()
        {
            // Create instance of your Repository
            _plcRepository = new PlcRepository();
            // Get the Data from the PLC Repository and fill your property
            PlcData = _plcRepository.GetData(12345);
        }
        public PlcData PlcData { get; set; }
    }
