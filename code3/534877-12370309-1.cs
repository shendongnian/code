    protected void SQL_Update(object sender, GridViewUpdateEventArgs e)
    {
       /*
         You'll have to find the control in the GridView, using FindControl, and cast it to a DropDownList  
         Using ddl.SelectedValue isn't going to work
       */
       string sql = "Update table set Status = " + ((DropDownList)Grid.Rows[e.RowIndex].FindControl("ddl")).SelectedValue 
       //Other SQL logic here
    
       //Commit the database changes, using whichever SQL driver you have.
    }
    
