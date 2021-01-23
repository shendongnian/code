        static public void createTable(string tableToCreate)
        {
            try
            {
                .
                .
                .
                .
            }
            catch (SqlException exp)
            {
                Console.WriteLine("Database not created: " + exp.Message, "Error");
                throw exp;
            }
        }
