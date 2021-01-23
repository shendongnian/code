    public class VCOM {
        public int Slot { get; set; }
        public string MessungNr { get; set; }
        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public string MessungAkt { get; set; }
        public decimal Durschnitt { get; set; }
    }
    private List<VCOM> _ListVCOM = new List<VCOM>();
    public List<VCOM> ListVCOM {
        get {
        return _ListVCOM;
        }
        set {
        _ListVCOM = value;
        OnPropertyChanged("ListVCOM");
        }
    }
