    namespace Zoho
    {
        public class DatabaseConnection
        {
            PotentialTableAdapter table;
            public DatabaseConnection()
            {
                table = new PotentialTableAdapter();
            }
            public DataTable Table
            {
                get
                {
                    return table.Table;
                }
            }
            public void Update()
            {
                try
                {
                    Console.Write("Attemping to update database: ");
                    table.Adapter.Update(Table);
                    Console.WriteLine("Success");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fail: {0}", ex.Message);
                }
            }
        }
    }
