    protected void gridEmployees_SelectedIndexChanged(object sender, EventArgs e) 
    { 
        int index = gridEmployees.SelectedIndex;
     
    //retrieve the Primary Key field from the SelectedDataKey property. 
      int ID = (int)gridEmployees.SelectedDataKey.Values["EmployeeID"];
     
    // Get other columns values 
    string firstName = gridEmployees.SelectedRow.Cells[2].Text; 
    string lastName = gridEmployees.SelectedRow.Cells[1].Text; 
    lblRegion.Text = gridEmployees.SelectedRow.Cells[9].Text;
      
    }
