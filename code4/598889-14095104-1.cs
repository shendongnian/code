    public class CFFPart
    {
        public int ID { get; set; }
        public ICollection<CFFPartDisp> CFFPartDisps { get; set; }
    }
    public class Disp
    {
        public int ID { get; set; }
        public ICollection<CFFPartDisp> CFFPartDisps { get; set; }
    }
