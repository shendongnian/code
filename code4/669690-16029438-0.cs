     protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
     {
        GridViewRow row = GridView1.Rows[e.RowIndex];
     
        TextBox txtName = (TextBox)row.FindControl("txtName");
        TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
        //     From here you can fire Update query on database.
        // Here you write code for store procedure.
     }
