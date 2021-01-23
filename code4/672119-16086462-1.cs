    namespace Userform
    {
        public partial class Form1 : Form
        {
            const string connectionString2 = @"Data Source=MyDatabase;Password=xxxxxx;";
    
            public Form1()
            {
                InitializeComponent();
            }
    
            // Some code between...
    
            private void button_ShowUsers_Click(object sender, EventArgs e) //code that shows users in listBox
            {
                var dt = new DataTable();
    
                using (var cn = new SqlCeConnection(connectionString2))
                using (var cmd = new SqlCeCommand("Select * From Users", cn))
                {
                    cn.Open();
    
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                        var results = (from row in dt.AsEnumerable()
                                       select new
                                       {
                                           //UserID = row.Field<int>("ID"),
                                           FirstName = row.Field<string>("Firsname"),
                                           LastName = row.Field<string>("Lastname"),
                                           FullName = row.Field<string>("Firstname") + " " + row.Field<string>("Lastname")
                                       }).ToList();
                        listBox_users.DataSource = results;
                        listBox_users.DisplayMember = "FullName";
                    }
                }
            }
        //I made an event for the listBox_users:
            private void listBox_users_SelectedIndexChanged(object sender, EventArgs e)
            //event code that should show listbox selected data in the textBoxes
            {
                if (listBox_inimesed.SelectedItem != null)
                {
                    using (var cn = new SqlCeConnection(connectionString2))
                    using (var cmd = new SqlCeCommand("Select * From Users", cn))
                    {
                        cn.Open();
    
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox1_firstname.Text = reader.GetString(1);
                                textBox2_lastname.Text = reader.GetString(2);
                                textBox3_email.Text = reader.GetString(3);
                                textBox4_address.Text = reader.GetString(4);
                                dateTimePicker1.Value = reader.GetDateTime(5);
                                richTextBox_info.Text = reader.GetString(6);
                            }
                            else MessageBox.Show("Object not found");
                        }
                    }
                }
            }
        }
    }
