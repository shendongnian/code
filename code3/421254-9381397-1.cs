    protected void Grid_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.AppSettings["connect"]);
    
        char value = "N"
    
        // You'll have to change the index here to point to the CheckBox you have in
        // your DataGrid.
        // It can be on index 1 Controls[1] or 2 Controls[2]. Only you know this info.
        if(((CheckBox)e.Item.Cells[0].Controls[0]).Checked == true)
        {
             value = "Y";;
        }
    
        cmd.Parameters.Add("@pric_c_alfsupreq", SqlDbType.Char).Value = value;
    
        cmd.CommandText = "Update command HERE";
    
        cmd.Connection = con;
    
        cmd.Connection.Open();
    
        cmd.ExecuteNonQuery();
    
        cmd.Connection.Close();
    
        Grid.EditItemIndex = -1;
    }
