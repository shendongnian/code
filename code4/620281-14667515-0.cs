        private bool IsLoading { get; set; }
    
        private void MyForm_Load(object sender, EventArgs e)
    {
        this.IsLoading = true;
    // do stuff
        this.IsLoading = false;
    }
    
    private void DataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
    {
                if (!this.IsLoading)
                {
                    return;
                }
    
       //do stuff
    }
