    protected void Save_Click(object sender, EventArgs e)
    {
         // I am doing some operations here then I am resetting the table as below
          com = new SqlCommand("UPDATE Loc_Pro_Grid SET Location_Profile = 0 WHERE Profiles='" +        ListBox1.Items[i].ToString() + "' ", con);
          con.Open();
          com.ExecuteNonQuery();
          con.Close();   
          // Call DataGrid's bind method here..for example
          grdFoo.DataBind()
    }
                   
