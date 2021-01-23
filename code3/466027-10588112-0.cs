    using System.Data;
    using CUBRID.Data.CUBRIDClient;
    using System.Data.Common;
    using System;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            string ConnectionString = "server=localhost;database=demodb;port=30000;user=dba;password=123456";
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            CUBRIDConnection con = new CUBRIDConnection(ConnectionString);
            CUBRIDCommand com = new CUBRIDCommand();
            com.CommandType = CommandType.Text; //Important ADO.NET driver crash using call convention
            com.Connection = con;
            com.CommandText = "select rset();";
            CUBRIDParameter pan = new CUBRIDParameter();
            con.Open();
            DbDataReader reader = com.ExecuteReader();
            CustomAdapter da = new CustomAdapter();
            da.FillFromReader(dt, reader);
            con.Close();
            DataRow fila = dt.Rows[0];
            Console.WriteLine(fila[0].ToString());
            Console.ReadKey();            
        }
    }
    
    public class CustomAdapter : System.Data.Common.DbDataAdapter
    {
        public int FillFromReader(DataTable dataTable, IDataReader dataReader)
        {
            return this.Fill(dataTable, dataReader);
        }
        protected override System.Data.Common.RowUpdatedEventArgs CreateRowUpdatedEvent(DataRow a, IDbCommand b, StatementType c, System.Data.Common.DataTableMapping d)
        {
            return (System.Data.Common.RowUpdatedEventArgs)new EventArgs();
        }
        protected override System.Data.Common.RowUpdatingEventArgs CreateRowUpdatingEvent(DataRow a, IDbCommand b, StatementType c, System.Data.Common.DataTableMapping d)
        {
            return (System.Data.Common.RowUpdatingEventArgs)new EventArgs();
        }
        protected override void OnRowUpdated(System.Data.Common.RowUpdatedEventArgs value)
        {
        }
        protected override void OnRowUpdating(System.Data.Common.RowUpdatingEventArgs value)
        {
        }
    } 
