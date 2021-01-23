    [DataContract]
    public class TernaryWebServiceResponse
    {
    
        [DataMember]
        public TernaryProcessingResultStatus ProcessingSuccessStatus { get; set; }
    
        [DataMember]
        private Dictionary<object, bool> mProcessingSuccessDetails;
    
        static public TernaryWebServiceResponse Create<T>(Dictionary<T, bool> list)
        {
            var dc = new TernaryWebServiceResponse();
            dc.mProcessingSuccessDetails = new Dictionary<object, bool>();
            foreach (var pair in list)
            {
                dc.mProcessingSuccessDetails.Add((object)pair.Key, pair.Value);
            }
            return dc;
        }
    
        public Dictionary<T, bool> ProcessingSuccessDetails<T>()
        {
            return mProcessingSuccessDetails.ToDictionary(x => ((T)x.Key), x => x.Value);
        }
    
    }
