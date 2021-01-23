    class Program
    {
        static void Main(string[] args)
        {
            //Application Properties can not change. They are read only
            //Properties.Settings.Default.testConnectionStringApplication 
            //    = String.Format("server={0};Port={1}; database={2};User Id={3};password={4}", "172.23.2.32", "3306", "hrm", "root", "test123");
    
            //User Properties can change
            Properties.Settings.Default.testConnectionStringUser
                = String.Format("server={0};Port={1}; database={2};User Id={3};password={4}", "172.23.2.32", "3306", "hrm", "root", "test123");
    
            //Call Save to persist the settings. 
            Properties.Settings.Default.Save();
    
            Console.WriteLine(Properties.Settings.Default.testConnectionStringUser);
            Console.ReadLine(); 
        }
    }
