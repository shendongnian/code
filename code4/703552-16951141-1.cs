    private void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e) Handles GridView1.RowCommand
    {
        if( e.CommandName == "Delete" ) {
            string TrainID  = GridView1.DataKeys(e.Row.RowIndex).Values("ID_Train");
            integer rc = 0;
            GridView1.DeleteParameters.Clear();
            GridView1.DeleteParameters.Add("Train_ID", TrainId);   // Adjust as necessary
            try{
                rc = GridView1.Delete();
                if( rc == 1) {
                   // Deleted
                } else {
                   // Not Deleted
                }
            }
            catch() {
                Label5.Text = "Error";
                Label5.Visible = true;
            }
        }
    }
