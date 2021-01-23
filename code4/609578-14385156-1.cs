    [Serializable()]
    public List<StepInstance> StepInstances { get { return mStepInstances; } { set { mStepInstances = value; } }
    
    private List<StepInstance> mStepInstances = new List<StepInstance>;
    
    ...
    
    [Serializable()]
    public class StepInstance {
        private string msPartnerKey = "";
        private string msObjectID = "";
    
        public string PartnerKey { get { return msPartnerKey; } set { msPartnerKey = value; } }
        public string ObjectID { get { return msObjectID; } set { msObjectID = value; } }
    }
