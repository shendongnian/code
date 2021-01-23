     public class ExpenseItem
        {
                [Key]
                public String UniqueID_ERLineID { get; set; }
                public String ERNum { get; set; }
                public String ItemNum { get; set; }
                public String Parent_Expense_Item_Key { get; set; }
                public String Card_Number { get; set; }
                public ExpenseItemAccounting Parent_Expense_Item { get; set; }
        }
