    public partial class LoginForm : Form
    {
        public bool letsGO = false;
        public LoginForm()
        {
            InitializeComponent();
            textUser.CharacterCasing = CharacterCasing.Upper;
        }
        public string UserName
        {
            get
            {
                return textUser.Text;
            }
        }
        private static DataTable LookupUser(string Username)
        {
            const string connStr = "Server=(local);" +
                                "Database=LabelPrinter;" +
                                "trusted_connection= true;" +
                                "integrated security= true;" +
                                "Connect Timeout=1000;";
            //"Data Source=apex2006sql;Initial Catalog=Leather;Integrated Security=True;";
            const string query = "Select password From dbo.UserTable (NOLOCK) Where UserName = @UserName";
            DataTable result = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = Username;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        result.Load(dr);
                    }
                }
            }
            return result;
        }
        private void HoldButton()
        {
            if (string.IsNullOrEmpty(textUser.Text))
            {
                //Focus box before showing a message
                textUser.Focus();
                MessageBox.Show("Enter your username", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Focus again afterwards, sometimes people double click message boxes and select another control accidentally
                textUser.Focus();
                textPass.Clear();
                return;
            }
            else if (string.IsNullOrEmpty(textPass.Text))
            {
                textPass.Focus();
                MessageBox.Show("Enter your password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                textPass.Focus();
                return;
            }
            //OK they enter a user and pass, lets see if they can authenticate
            using (DataTable dt = LookupUser(textUser.Text))
            {
                if (dt.Rows.Count == 0)
                {
                    textUser.Focus();
                    MessageBox.Show("Invalid username.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textUser.Focus();
                    textUser.Clear();
                    textPass.Clear();
                    return;
                }
                else
                {
                    string dbPassword = Convert.ToString(dt.Rows[0]["Password"]);
                    string appPassword = Convert.ToString(textPass.Text); //we store the password as encrypted in the DB
                    Console.WriteLine(string.Compare(dbPassword, appPassword));
                    if (string.Compare(dbPassword, appPassword) == 0)
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        //You may want to use the same error message so they can't tell which field they got wrong
                        textPass.Focus();
                        MessageBox.Show("Invalid Password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textPass.Focus();
                        textPass.Clear();
                        return;
                    }
                }
            }
        }
        private void textPass_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                HoldButton();
            }
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            HoldButton();
        }
        private void textPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                HoldButton();
            }
        }
    }
