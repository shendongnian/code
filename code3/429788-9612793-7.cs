    public class ExpenseItemAccounting
    {
        [Key]
        public String UniqueID_Accounting { get; set; }
        public ExpenseItem ExpenseItem{get;set;}
        public String ERLineID { get; set; }
        public String ERNum { get; set; }
        public String ItemNum { get; set; }
    }
