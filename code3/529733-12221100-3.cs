    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //GridViewRow row = (GridViewRow)GridView2.Rows[e.RowIndex];
        string LocName = GridView2.DataKeys[e.RowIndex].Values["Locations"].ToString();
        TextBox txt1 = (TextBox)GridView2.Rows[e.RowIndex].FindControl("Lamp_pro4");
        TextBox txt2 = (TextBox)GridView2.Rows[e.RowIndex].FindControl("Lamp_pro5");
        TextBox txt3 = (TextBox)GridView2.Rows[e.RowIndex].FindControl("AC_Profile5");
        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE Quantity set Lamp_pro4='" + txt1.Text + "',Lamp_pro5='" + txt2.Text + "',AC_Profile5='" + txt3.Text + "' where Locations=" + LocName, con);
        cmd.ExecuteNonQuery();
        con.Close();
        GridView2.EditIndex = -1;
        //BindQuantity();
        GridView2.DataBind();
    }
