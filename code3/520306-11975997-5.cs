    private void btnAddActivity_Click(object sender, EventArgs e)
    {
       activityName = txtActivityName.Text;    
       int index = dgvActivityList .Rows.Add();
       DataGridViewRow row = dgvActivityList .Rows[index];
       row.Cells[0].Value = activityName;      
       this.Close();           
    }   
