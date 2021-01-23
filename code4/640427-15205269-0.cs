    BeygirDataModeliContainer context; 
    private void Form1_Load(object sender, EventArgs e)
    {
        context = new BeygirDataModeliContainer()        
        beygirBindingSource.DataSource = context.BeygirSet; 
    }
    private void ApplyButton(object sender, EventArgs e)
    {
        context.SaveChanges();
    }
    private void CancelButton(object sender, EventArgs e)
    {
        context.Dispose();  
        context = new BeygirDataModeliContainer()
        beygirBindingSource.DataSource = context.BeygirSet;
        gridControl1.RefreshDataSource();
    }
  
    
