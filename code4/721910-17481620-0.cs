    public class StudyInfo
    {
        public string Modality { get; set; }
        public string StudyName { get; set; }
        public string ModalityId { get; set; }
        public string StudyID { get; set; }
        public int visitid { get; set; }
        public string billingId { get; set; }
        public string RegDate { get; set; }
        public string uploaded { get; set; }
        public string groupid { get; set; }
    }
    
    public class CustomerInformation
    {
        public string customerId { get; set; }
        public string CustomerName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public List<StudyInfo> StudyInfo { get; set; }
    }
    
    public class RootObject
    {
        public List<CustomerInformation> customerInformation { get; set; }
    }
