    private void BtnloadClick(object sender, EventArgs e)
    {
       if (null != cmbSource.SelectedItem)
       {
         string selectedITem = ((FeedSource) cmbSource.SelectedItem).Url;
         if (!string.IsNullOrEmpty(selectedITem))
         {     
            BindDataGrid(selectedITem);
         }            
    }
    private void BindDataGrid(string selectedItem)
    {
        for (int i = 0; i < 10; i++)
        {
          //Time consuming Process
        }
    }
