    public class myConnection
    {
        public static string GetConnectionString()
        {
            string connection = string.Empty;
            string path = "C:\\Users\\marek\\Documents\\Visual Studio 2012\\Projects\\tours\\tours\\sql_string.txt";
            using (StreamReader sr = new StreamReader(File.Open(path, FileMode.Open)))
            {
                connection = "Data Source='" + sr.ReadLine() + "';Initial Catalog ='" + sr.ReadLine() + "' ;User ='" + sr.ReadLine() + "';Password = '" + sr.ReadLine() + "'";
            } 
            
            return connection;
        }
    }
