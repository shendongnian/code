    public class Guru
    {
        public int Id { get; set; }
        public int? IdKotaLahir { get; set; }
        [ForeignKey("IdKotaLahir")]
        public virtual Kota KotaLahir { get; set; }
    }
    
