    public class Question
    {
        [DisplayName("Serial Number")]
        public int SrNo { get; set; }
    
        [Browsable(false)]
        public int QMID { get; set; }
    
        public string Question { get; set; }
    
        public int KioskId { get; set; }
    }
