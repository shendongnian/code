    public class CFFPartDisp
    {
        public int ID { get; set; }
        public int CFFPartID { get; set; }
        public CFFPart CFFPart { get; set; }
        
        public int DispID { get; set; }
        public Disp Disp { get; set; }
        public ICollection<Expert> Experts { get; set; }
    }
