    using System.Data.SqlClient;
    using System.Data;
    using System.IO;
    namespace ConsoleApplication4
    {
    class Program
    {
        static void Main(string[] args)
        {
            var connStr = "Data Source=MOHSINWIN8PRO\\SQLEXPRESS;Initial Catalog=AB2EDEMO;Integrated Security=True";
            var xmlFileData = "";
            DataSet ds = new DataSet();
            var tables = new[] {"Hospital", "Patient"};
            foreach (var table in tables)
            {
                var query = "SELECT * FROM "+ table +" WHERE (Hospital_Code = 'Hosp1')";
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                conn.Close();
                conn.Dispose();
                xmlFileData+=ds.GetXml();
            }
            File.WriteAllText("D://SelectiveDatabaseBackup.xml",xmlFileData);
        }
    }
