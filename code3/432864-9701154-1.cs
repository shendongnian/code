    namespace Con1
    {
        using System;
        using System.Data;
    
        using Oracle.DataAccess.Client;
    
        /// <summary>
        /// The program.
        /// </summary>
        internal class Program
        {
            #region Methods
    
            /// <summary>
            /// The main.
            /// </summary>
            private static void Main()
            {
                var con = new OracleConnection { ConnectionString = "User Id=usr;Password=pass;Data Source=XE" };
    
                con.Open();
                Console.WriteLine("Connected to Oracle" + con.ServerVersion);
    
                // create command to run your package
                var cmd = new OracleCommand("BEGIN pkgTestArrayBinding.TestArrayBinding(:Param1, :Param2); END;", con);
    
                var param1 = cmd.Parameters.Add("Param1", OracleDbType.Varchar2);
                var param2 = cmd.Parameters.Add("Param2", OracleDbType.Varchar2);
    
                param1.Direction = ParameterDirection.Input;
                param2.Direction = ParameterDirection.Input;
    
                // Specify that we are binding PL/SQL Associative Array
                param1.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                param2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
    
                // Setup the values for PL/SQL Associative Array
                param1.Value = new[] { "First Element", "Second Element ", "Third Element_" };
                param2.Value = new[] { "Fourth Element", "Fifth Element ", "Sixth Element " };
    
                // Specify the maximum number of elements in the PL/SQL Associative Array
                // this should be your array size of your parameter Value.
                param1.Size = 3;
                param2.Size = 3;
    
                // Setup the ArrayBindSize for each elment in the array, 
                // it should be bigger than the original length of element to avoid truncation
                param1.ArrayBindSize = new[] { 13, 14, 13 };
    
                // Setup the ArrayBindSize for Param2
                param2.ArrayBindSize = new[] { 20, 20, 20 };
    
                // execute the cmd
                cmd.ExecuteNonQuery();
    
                // I am lazy to query the database table here, but you should get you data now.
                // watch what happened to element "Third Element_"
    
                // Close and Dispose OracleConnection object
                con.Close();
                con.Dispose();
                Console.WriteLine("Disconnected");
            }
    
            #endregion
        }
    }
