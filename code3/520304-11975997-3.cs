    private void btnAddActivity_Click(object sender, EventArgs e)
    {
       activityName = txtActivityName.Text;    
       int index = yourDataGridView.Rows.Add();
       DataGridViewRow row = yourDataGridView.Rows[index];
       row.Cells[0].Value =   activityName;      
       this.Close();           
    }   
