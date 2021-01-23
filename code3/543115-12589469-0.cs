    using(var conn = new SqlConnection(connString))
    {
       SqlCommand cmdd = new SqlCommand("registrtn", conn);
       cmdd.CommandType = CommandType.StoredProcedure;
       cmdd.Parameters.Add("@empid",SqlDbType.VarChar,50).Value = textBox7_empid.Text;
       cmdd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = textBox6_name.Text;
       cmdd.Parameters.Add("@desgination", SqlDbType.VarChar, 50).Value = textBox5_desgination.Text;
       cmdd.Parameters.Add("@emailid", SqlDbType.VarChar, 50).Value = textBox4_emailid.Text;
       cmdd.Parameters.Add("@phone", SqlDbType.VarChar, 50).Value = textBox3_phoneno.Text;
       cmdd.Parameters.Add("@skype", SqlDbType.VarChar, 50).Value = textBox1_skpid.Text;
       cmdd.Parameters.Add("@address", SqlDbType.VarChar, 50).Value = textBox1_add.Text;
       cmdd.Parameters.Add("@shifttime", SqlDbType.VarChar, 50).Value = comboBox1_shifttime.SelectedText;
       cmdd.Parameters.Add("@panel", SqlDbType.VarChar, 50).Value = radioButton1_employe.Checked.ToString();
       cmdd.ExecuteNonQuery();
    }
