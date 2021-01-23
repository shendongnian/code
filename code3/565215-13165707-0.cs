    static void Main(string[] args)
    {
    //Connection String
    String ConnectionString = @"Data Source = localhost\SQLEXPRESS; Initial Catalog = School; Trusted_Connection=True;";
    
    //Create the Connection
    SqlConnection DbConn = new SqlConnection(ConnectionString);
    
    //Open the Connection
    DbConn.Open();
    
    //Query String
    String QueryString = "SELECT * FROM COURSE";
    
    //Create the SqlCommand Object
    SqlCommand QueryCommand = new SqlCommand(QueryString, DbConn);
    
    //Use the SqlCommand to create the DataReader Object.
    SqlDataReader QueryCommandReader = QueryCommand.ExecuteReader();
    
    //Create the Datatable.
    DataTable DataT = new DataTable();
    
    //Load the Data into the Table.
    DataT.Load(QueryCommandReader);
    
    //Get the User Input
    String Expression = "Credits > 3";
    
    //Create DataRows and Filter Table.
    List<DataRow> FilteredData = new List<DataRow>();
    FilteredData = DataT.Select(Expression).ToList();
    }
