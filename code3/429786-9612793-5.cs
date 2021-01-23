    public class ExpenseItem
    {
            [Key]
            public String UniqueID_ERLineID { get; set; }
            public String ERNum { get; set; }
            public String ItemNum { get; set; }
            public String Parent_Expense_Item { get; set; }
            public String Card_Number { get; set; }
            public ICollection<ExpenseItemAccounting> ExpenseItemAccountings{ get; set; }
    }
