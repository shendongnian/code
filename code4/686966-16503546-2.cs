    public partial class Form1 : Form
    {
        public MySqlConnection connection;
        public Form1()
        {
            
            InitializeComponent();
            
            //DBInfo db = new DBInfo(); // would comment this out since you're not using it
            string server;
            string database;
            string uid;
            string password;
            
            server = "XXX";
            database = "XXX";
            uid = "XXX";
            password = "XXX";
            string connectionString;
            connectionString = "Server=" + server + ";" + "Database=" + database + ";"
                    + "Uid=" + uid + ";" + "Password" + password + ";";
            
            //connection = new MySqlConnection(connectionString); // not here - for troubleshooting at least
            
            try
            {
                connection = new MySqlConnection(connectionString); // relocated from above for troubleshooting
                connection.Open(); // uncommented again with the try/catch wrapping it
            }
            (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
