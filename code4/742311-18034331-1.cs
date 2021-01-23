    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        Match match = Regex.Match(TextBox1.Text, @"^\d{4}[A-Z]{5}\d{3}$");
        if (match.Success)
        {
            DropDownList1.Focus();
            string dpt = (string) Session["deptmnt"];
            idd = TextBox1.Text;
            Label33.Text = idd;
            string val = idd;
            string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con1 = new SqlConnection(con))
            {
                String str = "SELECT * from student where sid=@val";
                con1.Open();
                using (SqlCommand cmd = new SqlCommand(str, con1))
                {
                    cmd.CommandType = CommandType.Text;
                    SqlParameter sql;
                    cmd.Parameters.Clear();
                    sql = cmd.Parameters.Add("@val", SqlDbType.VarChar, 20);
                    sql.Value = val;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows == false)
                    {
                        Label35.Visible = true;
                        TextBox1.Text = "";
                    }
                    else
                    {
                        Panel3.Visible = true;
                        DropDownList1.Focus();
                        while (reader.Read()) // if can read row from database
                        {
                            Panel3.Visible = true;
                            Label3.Text = reader["sname"].ToString();
                            Label5.Text = reader["dept"].ToString();
                            Label25.Text = reader["yr"].ToString();
                        }
                        cmd.Parameters.Clear();
                    }
                }
            }
            using (SqlConnection con2 = new SqlConnection(con))
            {
                string val1 = idd;
                string str2 = "SELECT bid from studentissuebook where sid=@val1 AND status='" + "lost" + "'";
                con2.Open();
                using (SqlCommand cmd2 = new SqlCommand(str2, con2))
                {
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.Clear();
                    SqlParameter sql2;
                    sql2 = cmd2.Parameters.Add("@val1", SqlDbType.VarChar, 20);
                    sql2.Value = val1;
                    SqlDataReader reader1 = cmd2.ExecuteReader();
                    if (reader1.HasRows == false)
                    {
                        TextBox1.Text = "";
                        Label39.Visible = true;
                        Panel3.Visible = false;
                    }
                    else
                    {
                        DropDownList1.Focus();
                        while (reader1.Read()) // if can read row from database
                        {
                            DropDownList1.Items.Add(reader1[0].ToString());
                        }
                        DropDownList1.Focus();
                    }
                }
            }
        }
        else
        {
            formatlabel.Visible = true;
        }
    }
