    private BindingSource bs = new BindingSource();
    private MyDbContext context = new MyDbContext();
    
    context.MyEntities.Where(x=>x.SomeProperty == 2).Load(); 
    bs.DataSource = context.MyEntities.Local.ToBindingList(); 
    myDataGridView.DataSource = bs;
