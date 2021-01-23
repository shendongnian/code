    private void button1_Click(object sender, EventArgs e)
        {
            List<string> validationErrors = new List<string>();
            Regex regexObj = new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
            if (regexObj.IsMatch(textBox3.Text))
            {
                string formattedPhoneNumber =
                    regexObj.Replace(textBox3.Text, "($1) $2-$3");
            }
            else
            {
                validationErrors.Add("Invalid Phone Number! \nFormat is (XXX) XXX-XXXX");
            }
            if (string.IsNullOrEmpty(textBox1.Text) || textBox1.Text.Trim().Length == 0)
            {
                validationErrors.Add("Field can't be left blank!");
            }
            if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text.Trim().Length == 0)
            {
                validationErrors.Add("No Name for the Author!");
            }
            if (validationErrors.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, validationErrors.ToArray()));
                return;
            }
            SqlConnection con = new SqlConnection("Server = DAFFODILS-PC\\SQLEXPRESS;Database=Library;Trusted_Connection=True;");
            SqlCommand sql1 = new SqlCommand("INSERT into Members VALUES('" + textBox1.Text + "' , '" + textBox2.Text + "','" + textBox3.Text + "')", con);
            con.Open();
            sql1.ExecuteNonQuery();
            con.Close();
            this.membersTableAdapter.Fill(this.booksDataSet.Members);
            MessageBox.Show("Data Added!");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Focus();
        }
    }
