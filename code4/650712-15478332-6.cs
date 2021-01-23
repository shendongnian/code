        public class ExpenseDataMapper
        {
            SQLiteConnection connection;
    
            /// <summary>
            /// Constructor
            /// </summary>
            public ExpenseDataMapper()
            {
                connection = new SQLiteConnection(StaticResources.DATABASE_PATH_NAME);
    
                connection.CreateTable<FinancialListBoxExpenseItem>();
            }
    
            /// <summary>
            /// Inserts an FinancialListBoxExpenseItem into Database
            /// </summary>
            /// <param name="item"></param>
            /// <returns>Primary key of inserted item</returns>
            public int insertExpenseItem(FinancialListBoxExpenseItem item)
            {
                int primaryKey = 0;
                connection.RunInTransaction(() =>
                                {
                                    connection.Insert(item);
                                    //primaryKey = connection.ExecuteScalar<int>("SELECT last_insert_rowid()");
                                    //item.expenseID = primaryKey;
                                    primaryKey = item.expenseID;
                                });
    
                return primaryKey;
            }
    }
