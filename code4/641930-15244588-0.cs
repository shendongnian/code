    public class EntityAdresse : IEntityADRESSE
    {
        private static readonly Func<EntityAdresse,string> s_ToString=Generator.GenerateToString<EntityAdresse>();
    
        public string Name1 { get; set; }
        public string Strasse { get; set; }
        public string Plz { get; set; }
        public string Ort { get; set; }
        public string NatelD { get; set; }
        public string Mail { get; set; }
        public int Id_anrede { get; set; }
        public string Telefon { get; set; }
        public int Id_adr { get; set; }
        public int Cis_adr { get; set; }
    
        public override ToString()
        {
           return s_ToString(this);
        }
    }
