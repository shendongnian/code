    [Table("Shifts")]
    public class Shift : MPropertyAsStringSettable {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int SiteID { get; set; }
        public string ShiftID_In_POS { get; set; }
        public DateTime ShiftDate { get; set; }
    }
