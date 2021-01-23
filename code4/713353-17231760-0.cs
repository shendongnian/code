    cmd.Parameters.AddWithValue("@Emp_No", textBox1.Text);
    if (radioButton1.Checked)
    {
        cmd.Parameters.AddWithValue("@Gender", radioButton1.Text);
    }
    else
    {
        cmd.Parameters.AddWithValue("@Gender", radioButton2.Text);
    }
    
    string languages = new List<string>();
    
    if (checkBox1.Checked)
    {
        languages.Add(checkBox1.Text);
    }
    if (checkBox2.Checked)
    {
        languages.Add(checkBox2.Text);
    }
    if (checkBox3.Checked)
    {
        languages.Add(checkBox3.Text);
    }
    if (checkBox4.Checked)
    {
        languages.Add(checkBox4.Text);
    }   
    
    cmd.Parameters.AddWithValue("@Language", string.Join(",", languages.ToArray());
    
    cmd.ExecuteNonQuery();
    con.Close();
