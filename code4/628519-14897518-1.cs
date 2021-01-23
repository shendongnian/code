    DataSet ds = null;
    if (radioButton1.Checked == true && checkEbayName(textBox1.Text) == true )
    {
        ds = GetUserByEbayName(textBox1.Text);
        if (ds != null)
            dataGridView1.DataSource = ds.Tables["Customer"];
    }
    else if (radioButton2.Checked == true && checkName(textBox1.Text) == true)
    {
        ds = GetUserByName(textBox1.Text);
        if (ds != null)
            dataGridView1.DataSource = ds.Tables["Customer"];
    }
    // Show the user that we have not found customers not by ebayname or username
    if(ds == null)
        MessageBox.Show("No Customer with matching details");
