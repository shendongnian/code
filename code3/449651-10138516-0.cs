    public class Detail
    {
        private string _masterID;
        public string MasterID { 
            get {
                return _masterI;
            }
            set {
                _masterID = value;
                Master = FindMasterById(value);
            }
        }
        public Master Master { get ; set ; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
    }
