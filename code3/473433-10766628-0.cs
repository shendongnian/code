    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
      // get the row being updated
      GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
    
      // use the FindControl method to retrieve the control holding the ID
      Label lbl = (Label)row.FindControl("lblid");
    
      // you can find other controls as needed using the same method
      TextBox tb1 = (TextBox)row.FindControl("textbox1");
      TextBox tb2 = (TextBox)row.FindControl("textbox2");
    
      // perform the SQL update, or whatever using the ID (here's your original code)
    
      string constr = "con string";          
      string statment = "Select Name from tb1 Where [ID] = " + lbl.Text;          
      using (SqlConnection con = new SqlConnection(constr))          
      {          
        using (SqlCommand comm = new SqlCommand(statment, con))          
        {          
          con.Open();          
          Label2.Text = comm.ExecuteScalar().ToString();          
          con.Close();          
        }          
      } 
    }
