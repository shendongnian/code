    namespace WindowsFormsApplication1.DataSet1TableAdapters
    {
        public partial class ProductTableAdapter 
        {
            public string ConnectionString {
                get { return Connection.ConnectionString; }
                set { Connection.ConnectionString = value; }
            }
        }
    }
