        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                LoadCustomerOnCombo();
            }
            private void LoadCustomerOnCombo()
            {
                string strCon = Settings.Default.PID2dbConnectionString;
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(strCon))
                    {
                        conn.Open();
                        string strSql = "SELECT forename, surname FROM customer"; //WHERE [customerID] ='" + txtName.Text + "'";
                        OleDbDataAdapter adapter = new OleDbDataAdapter(new OleDbCommand(strSql, conn));
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        cboName.DataSource = ds.Tables[0];
                        cboName.DisplayMember = "forename";
                        cboName.ValueMember = "surname";
                    }
                
                }
                catch (Exception ex)
                {
                    txtName.Text = ex.Message;
                    Console.WriteLine(ex.Message);
                }
            }
        }
