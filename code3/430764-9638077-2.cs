    public class Mietzins
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
