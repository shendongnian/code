    var selectedLines = CheckBoxList1.Items.Cast<ListItem>()
                 .Where(li => li.Selected)
                 .Select(li => li.Text);
    using (var con = new SqlConnection(connectionString))
    using (var cmd = new SqlCommand("Insert into t_ap_line_setup  (line,date) values (@line,getdate())", con))
    {
        con.Open();
        foreach (string line in selectedLines)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@line", line);
            cmd.ExecuteNonQuery();
        }
    }
