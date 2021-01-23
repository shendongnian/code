    class Program
    {
        static string connectionString = "Server=.;Database=test_sql_dependency;Integrated Security=True;";
        static void Main(string[] args)
        {
            // 1. create database
            // 2. enable service broker by executing this sql command on the database.
            // alter database test_sql_dependency set enable_broker
            // 3. start sql dependency, for some sql server connection string or with queue if you want.
            //var queueName = "myFirstQueue";
            //SqlDependency.Start(connectionString, queueName);
            SqlDependency.Start(connectionString);
            // complete the rest of the steps in seperate method to be able to call it again when you need to 
            // re-subscribe to the event again, becuase by default it will be executed only one time
            RegisterSqlDependency();
            Console.WriteLine("Listening to database changes...");
            Console.ReadLine();
        }
        static void RegisterSqlDependency()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                // 4. create a sql command 
                // you can't say select *, and also you have to specefy the db owner (dbo.)
                SqlCommand command = new SqlCommand("select Id, Name from dbo.Employee", connection);
                // 5. create dependency and associtate it to the sql command
                SqlDependency dependency = new SqlDependency(command);
                // 6. subscribe to sql dependency event
                dependency.OnChange += new OnChangeEventHandler(OnDependencyChange);
                // 7. execute the command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                }
            }
        }
        static void OnDependencyChange(object sender, SqlNotificationEventArgs e)
        {
            var InsertOrUpdateOrDelte = e.Info;
            //-----------------------------Finally-------------------------
            // after you knew that there is a change happened 
            // you have to unsubscribe the event and execute the command again and then re-subscribe to the event
            // 1. unsubscribe the event
            SqlDependency dependency = sender as SqlDependency;
            dependency.OnChange -= OnDependencyChange;
            // 2. re-subscribe to the event and execute the command again
            RegisterSqlDependency();
            
        }
    }
