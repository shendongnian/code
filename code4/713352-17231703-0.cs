    StringBuilder sb = new StringBuilder();
    if (checkBox1.Checked)
    {
         sb.Append(checkBox1.Text);
    }
    if (checkBox2.Checked)
    {
         sb.Append(checkBox2.Text);
    }
    if (checkBox3.Checked)
    {
        sb.Append(checkBox3.Text);
    }
    if (checkBox4.Checked)
    {
        sb.Append(checkBox4.Text);
    }
    cmd.Parameters.AddWithValue("@Language", sb.ToString());
