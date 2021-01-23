    To Read a single table from MySql database which is in wamp server.
    If wamp-server is in localhost then,
    Add reference ..
    using MySql.Data.MySqlClient;
    And after this..
    write below public partial class this connection query..
    MySqlConnection cn = new        
    MySqlConnection
    ("server=localhost;database=database;userid=root;password=;charsetutf8;");
    write this GetData() in your form load event or below InitializeComponent...
 
    private void GetData()
        {
            cn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * from                                      
            tablename", cn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridViewName.DataSource = dt;
            adp.Dispose();
            cn.Close();
        }
