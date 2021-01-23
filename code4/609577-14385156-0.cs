    [Serializable()]
    public List<StepInstance> StepInstances = new List<StepInstance>;
        
    ...
    [Serializable()]
    public class StepInstance {
        public string PartnerKey = "";
        public string ObjectID = "";
    }
