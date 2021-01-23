    StringBuilder filter = new StringBuilder();
    if (!(string.IsNullOrEmpty(textBox1.Text)))
        .Append("Column1 Like '%" + textBox1.Text + "%'");
    if (!(string.IsNullOrEmpty(textBox2.Text)))
    {
       if (filter.Length > 0)
           filter.Append("OR Column2 Like '%" + textBox2.Text + "%'");
       else
           filter.Append("Column2 Like '%" + textBox2.Text + "%'");
    }
    if (!(string.IsNullOrEmpty(textBox3.Text)))
    {
       if (filter.Length > 0)
            filter.Append("OR Column3 Like '%" + textBox3.Text + "%'");
       else
            filter.Append("Column3 Like '%" + textBox3.Text + "%'");
    }
    DataView dv = dt.DefaultView;
    dv.RowFilter = filter.ToString();
