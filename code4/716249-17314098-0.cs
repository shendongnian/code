    StringBuilder filter = new StringBuilder();
    if (!(string.IsNullOrEmpty(textBox1.Text)))
        filter.Append("Column1 Like '%" + textBox1.Text + "%'");
    if (!(string.IsNullOrEmpty(textBox2.Text))) 
        filter.Append("OR Column2 Like '%" + textBox2.Text + "%'");
    if (!(string.IsNullOrEmpty(textBox3.Text)))
        filter.Append("OR Column3 Like '%" + textBox3.Text + "%'");
    DataView dv = dt.DefaultView;
    dv.RowFilter = filter.ToString();
