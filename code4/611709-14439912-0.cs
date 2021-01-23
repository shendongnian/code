    DataGridViewRow row = new DataGridViewRow();
    if (tabControl1.SelectedTab.Name == "Name1") 
    {
         row = dataGridView1.CurrentRow;
    }
    else
    {
        if (tabControl1.SelectedTab.Name == "Name2") 
        {
            row = dataGridView2.CurrentRow;
        }
        else
        {
            row = dataGridView3.CurrentRow;
        }
    if (row != null)
    {
        //your logic here
    }
 
