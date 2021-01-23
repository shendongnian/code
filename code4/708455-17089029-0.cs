    public class BaseRootObject
    {
        public List<RootObject> Values { get; set; }
    }
    public class RootObject
    {
        public int ID { get; set; }
        public string SkladisteSifra { get; set; }
        public string SkladisteNaziv { get; set; }
        public object StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string Broj { get; set; }
        public string Datum { get; set; }
        public string PartnerSifra { get; set; }
        public string PartnerNaziv { get; set; }
        public string Napomena { get; set; }
        public string TipDokumenta { get; set; }
        public bool Odobriti { get; set; }
        public bool Editable { get; set; }
    }
