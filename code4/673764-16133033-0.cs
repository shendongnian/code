    public class ItemElectronic //underscore is not C# convention for class name
    {
        //Auto properties simplifies usage and create backing field behind the scene
        public String Id { get; set; }
        public String Type { get; set; }
        public String Manufacturer { get; set; }
        public String Make { get; set; }
        public String ModelNo { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public ItemElectronic()
        {
           //It's not appropiate to call DB connection in constructor as it could result in exception
           //connectDB(); 
        }
    }
    
    // Create another class to provide DataAccess to your entity class 
    public class ItemElectronicDataAccess
    {
        OleDbConnection _connection;
        OleDbCommand _command;
        string queryString;
        public void ConnectDb()
        {
            _connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\rummykhan\MCS\Spring 2013\Object Oriented Programming\My Apps\MyProject\c Projects\My Class Project\Projects Database\IMSDatabase.accdb");
        }
        public void Insert(ItemElectronic product)
        {
            try
            {
                queryString = "Insert INTO Electronics (eID,eType,eManufacturer,eMake,eModelNo,ePrice,eQuantity) Values('" + product.Id + "','" + product.Type
                    + "','" + product.Manufacturer + "','" + product.Make + "','" + product.ModelNo + "','" + product.Price
                    + "','" + product.Quantity + "')";
                _command = new OleDbCommand(queryString, _connection);
                _connection.Open();
                _command.ExecuteNonQuery();
                _connection.Close();
                MessageBox.Show("Test");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (_connection != null && _connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                    _connection.Dispose();
                }
            }
        }
    }
