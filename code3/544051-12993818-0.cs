    using System;
    using System.Transactions;
    using System.Data;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    namespace StackOverflow.Demos
    {
        class Program
        {
            static Database db = DatabaseFactory.CreateDatabase("demo");
            public static void Main(string[] args)
            {
                TransactionOptions options = new TransactionOptions();
                options.IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead; //see http://www.gavindraper.co.uk/2012/02/18/sql-server-isolation-levels-by-example/ for a helpful guide to choose as per your requirements
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
                {
                    using (IDbConnection connection = db.CreateConnection())
                    {
                        connection.Open(); //nb: connection must be openned within transactionscope in order to take part in the transaction
                        IDbCommand command = connection.CreateCommand();
                    
                        command.CommandType = CommandType.Text;
                        command.CommandText = "select top 1 status from someTable with(UPDLOCK, ROWLOCK) where id = 1"; //see http://msdn.microsoft.com/en-us/library/aa213026(v=sql.80).aspx
                        string statusResult = command.ExecuteScalar().ToString();
                    
                        if (!statusResult.Equals("closed",StringComparison.OrdinalIgnoreCase))
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText = "update someTable set status='closed' where id = 1";
                        }
                        scope.Complete();
                    }
                }
            }
        }
    }
