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
