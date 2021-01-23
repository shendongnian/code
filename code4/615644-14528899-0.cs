    public class Parts
    {
        public string PartCode { get; set; }
        public string PartName { get; set; }
        public string PartNo
        {
            get
            {
                return PartCode + PartName;
            }
            set;
        }
    }
