    private void Test(string department)
        {
            //Create a dictionary using the manager as the key, employees for the values
            List<Employee> employees = new List<Employee>();
            DirectoryEntry de = new DirectoryEntry("LDAP://server.server.com");
            DirectorySearcher ds = new DirectorySearcher(de);
            ds.Filter = String.Format(("(&(objectCategory=person)(objectClass=User)(department={0}))"), department);
            ds.SearchScope = SearchScope.Subtree;
            foreach (SearchResult temp in ds.FindAll())
            {
                Employee e = new Employee();
                e.Manager = temp.Properties["Manager"][0].ToString();
                e.UserId = temp.Properties["sAMAccountName"][0].ToString();
                e.Name = temp.Properties["displayName"][0].ToString();
                employees.Add(e);
            }
        }
        public class Employee
        {
            public string Name { get; set; }
            public string Manager { get; set; }
            public string UserId { get; set; }
        }
