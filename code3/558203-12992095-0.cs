    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                // Where possible, move code out of specific event handlers
                // into methods which can be re-used from other client code. 
                // Here, I pulled the actual data access out into separate methods, 
                // and simply call it from the event handler:
                this.LoadGridView(textBox1.Text);
            }
            private void LoadGridView(string UserID)
            {
                // Now we can load the gridview from other places in our
                // code if needed:
                this.dataGridView1.DataSource = this.MyUsers(UserID);
            }
            private DataTable MyUsers(string UserID)
            {
                var dt = new DataTable();
                // Use a SQL Paramenter instead of concatenating criteria:
                string SQL = "SELECT * FROM Leave WHERE userid = @UserID";
                // The "using" statement limits the scope of the connection and command variables, and handles disposal
                // of resources. Also note, the connection string is obtained from the project properties file:
                using(OleDbConnection cn = new OleDbConnection(Properties.Settings.Default.MyConnectionString))
                {
                    using (var cmd = new OleDbCommand(SQL, cn))
                    {
                        // For simpler things, you can use the "AddWithValue" method to initialize a new parameter, 
                        // add it to the Parameters collection of the OleDBCommand object, and set the value:
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        // Get in, get out, get done:
                        cn.Open();
                        dt.Load(cmd.ExecuteReader());
                        cn.Close();
                    }
                }
                return dt;
            }
        }
    }
