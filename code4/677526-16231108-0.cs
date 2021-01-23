    public class CommonFields
    {
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public virtual User ModifiedBy { get; set; }
        public int? ModifiedById { get; set; }
    }
