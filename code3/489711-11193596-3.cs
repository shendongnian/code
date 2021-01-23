    GridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    DataGridViewRow row = GridView1.SelectedRows[0];
    
    OleDbCommand cmd = new OleDbCommand(   
    using (var cn = new OleDbConnection(strConn))
    {
       cn.Open();
       // not 100% this delete syntax is correct for Access
       using (var cmd = new OleDbCommand("DELETE booking WHERE [Booking ID] = @BookingId", cn)) 
       {
           cmd.Parameters.AddWithValue("@BookingId", dRow["Booking Id"]);
           cmd.ExecuteNonQuery();     
       }
    }
    // Do this to update the in-memory representation of the Data
    DataRow dRow = (DataRow)row.DataBoundItem;
    dt.Rows.Remove(dRow);
    // Or just refresh the datatable using code similar as your search methods 
