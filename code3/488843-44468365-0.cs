    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    
    namespace XYZ
    {
        public class TransactionsModule
        {
            public List<Person> GetPersons(string query, string connectionString)
            {
                List<Person> dbItems = new List<Person>();
                
                OleDbConnection conn = new OleDbConnection(connectionString);
    
                try 
                {
                    conn.Open();
                    var cmd = new OleDbCommand(query, conn);
                    cmd.CommandText = query;
    
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        Person objPerson = new Person();
                        
                        //These are the columns returned
                        objPerson.Name = Convert.ToString(myReader["Name"]);
                        objPerson.Age = Convert.ToInt32(myReader["Age"]);
    
                        dbItems.Add(objPerson);
                    }
                } 
                catch(OleDbException ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
                return dbItems;           
            }
    
        }
    
        //This class should be in another Layer, but I placed it here since It's a quick Example
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
