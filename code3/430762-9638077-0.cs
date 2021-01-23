    public class Mietzins
    {
        public int Id { get; set; }
        public int LiegenschaftId { get; set; }
        public int MieterId { get; set; }
        public int ObjektId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Liegenschaft Liegenschaft { get; set; }
        public Mieter Mieter { get; set; }
        public Objekt Objekt { get; set; }
    }
    public class Mieter
    {
        public int Id { get; set; }
        public int LiegenschaftId { get; set; }
        public int ObjektId { get; set; }
        public string Name { get; set; }
        public Liegenschaft Liegenschaft { get; set; }
        public ICollection<Mietzins> MietzinsMenge { get; set; }
        public Objekt Objekt { get; set; }
    }
    public class Objekt
    {
        public int Id { get; set; }
        public int LiegenschaftId { get; set; }
        public int HausId { get; set; }
        public int Zimmer { get; set; }
        public Haus Haus { get; set; }
        public Liegenschaft Liegenschaft { get; set; }
        public ICollection<Mietzins> MietzinsMenge { get; set; }
        public ICollection<Mieter> MieterMenge { get; set; }
    }
    public class Liegenschaft
    {
        public int Id { get; set; }
        public string Strasse { get; set; }
        public int UserId { get; set; }
        public ICollection<Haus> HausMenge { get; set; }
        public ICollection<Mieter> MieterMenge { get; set; }
        public ICollection<Mietzins> MietzinsMenge { get; set; }
        public ICollection<Objekt> ObjektMenge { get; set; }
    }
    public class Haus
    {
        public int Id { get; set; }
        public int LiegenschaftId { get; set; }
        public int Nummer { get; set; }
        public ICollection<Objekt> ObjektMenge { get; set; }
        public Liegenschaft Liegenschaft { get; set; }
    }
