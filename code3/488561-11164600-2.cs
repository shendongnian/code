    public partial class SubEtage : Etage
    {
        public override string Beschreibung
        {
            get { return base.Beschreibung; }
            set { base.Beschreibung = value + "GEHT"; }
        }
        
        public override string ToString()
        {
            return String.Format("{0}", Beschreibung);
        }
    }
