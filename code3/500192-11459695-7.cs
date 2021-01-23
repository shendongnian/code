    using System; 
    using System.Collections.Generic; 
    using System.Linq; 
    using System.Runtime.Serialization; 
    using System.ServiceModel; 
    using System.Text; 
    using System.Data; 
    using System.Data.SqlClient; 
     
    namespace WcfServiceLibrary1 
    { 
        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together. 
        public class Service1 : IService1 
        { 
            public List<Employee> GetEmployee(string firstName)  
     
            { 
                //Create Connection  
                SqlConnection con = new SqlConnection(@"Data Source=gsops4;Initial Catalog=MultiTabDataAnalysis;Integrated Security=true;"); 
     
                //Sql Command  
                SqlCommand cmd = new SqlCommand("Select LastName, FirstName, Email, University from Employees where FirstName ='" + firstName.ToUpper() + "'", con); 
     
                //Open Connection  
                con.Open(); 
     
                List<Employee> employees = new List<Employee>(); 
     
                //To Read From SQL Server  
                SqlDataReader dr = cmd.ExecuteReader();  
     
     
                while (dr.Read())  
            {  
                var employee = new Employee {   
                            
                           FirstName = dr["FirstName"].ToString(),  
                           LastName = dr["LastName"].ToString(), 
                           Email = dr["Email"].ToString(), 
                           University = dr["University"].ToString() 
                              
     
     
                        };  
                employees.Add(employee);  
            }  
            //Close Connection  
            dr.Close();  
            con.Close();  
            return employees; 
     
            } 
     
            public CompositeType GetDataUsingDataContract(CompositeType composite) 
            { 
                if (composite == null) 
                { 
                    throw new ArgumentNullException("composite"); 
                } 
                if (composite.BoolValue) 
                { 
                    composite.StringValue += "Suffix"; 
                } 
                return composite; 
            } 
        } 
    } 
 
