    public class TennisCourt
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Extérieur ?")]//=Outside in french
        [Column("Outside")]
        public bool Outside { get; set; }
    }
