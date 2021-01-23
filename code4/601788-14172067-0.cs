     public Person SomeMethod(string fName)
            {
                var con = ConfigurationManager.ConnectionStrings["Yourconnection"].ToString();
    
                Person matchingPerson = new Person();
                using (SqlConnection myConnection = new SqlConnection(con))
                {
                    string oString = "Select * from Employees where FirstName=@fName";
                    SqlCommand oCmd = new SqlCommand(oString, myConnection);
                    oCmd.Parameters.AddWithValue("@Fname", fName);           
                    myConnection.Open();
                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {    
                            matchingPerson.firstName = oReader["FirstName"].ToString();
                            matchingPerson.lastName = oReader["LastName"].ToString();                       
                        }
    
                        myConnection.Close();
                    }               
                }
                return matchingPerson;
            }
