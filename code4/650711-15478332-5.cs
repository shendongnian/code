     public class FinancialListBoxExpenseItem : Money.Common.BindableBase
        {
    
            private int _expenseID = 0;
            [AutoIncrement, PrimaryKey]
            public int expenseID
            {
                get
                {
                    return _expenseID;
                }
    
                set
                {
                    this.SetProperty<int>(ref _expenseID, value);
                }
            }
    }
