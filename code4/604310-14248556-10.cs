    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Click += new EventHandler(button1_Click);
            this.FillDropDownList();
        }
        void button1_Click(object sender, EventArgs e)
        {
            this.SaveComboBoxContent();
        }
        public void FillDropDownList()
        {
            string SQL = "SELECT id, name FROM info ORDER BY name";
            DataTable dt = new DataTable();
            // Set the connection string in the Solutions Explorer/Properties/Settings object (double-click)
            using (var cn = new SqlConnection(Properties.Settings.Default.MyConnectionString))
            {
                using(var cmd = new SqlCommand(SQL, cn))
                {
                    cn.Open();
                    try
                    {
                        dt.Load(cmd.ExecuteReader());
                    }
                    catch (SqlException e)
                    {
                        // Do some logging or something. 
                        MessageBox.Show("There was an error accessing your data. DETAIL: " + e.ToString());
                    }
                }
            }
            // UPDATED - The .ValueMember and .DisplayMember properties 
            // refer to the string name of the field (oops!):
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";
        }
        public void SaveComboBoxContent()
        {
            string SQL = "INSERT INTO info2 (name_id) VALUES (@name_id)";
            using (var cn = new SqlConnection(Properties.Settings.Default.MyConnectionString))
            {
                using(var cmd = new SqlCommand(SQL, cn))
                {
                    cmd.Parameters.AddWithValue("@name_id", comboBox1.SelectedValue);
                    cn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        // Do some logging or something. 
                        MessageBox.Show("There was an error accessing your data. DETAIL: " + e.ToString());
                    }
                }
            }
        }
    }
