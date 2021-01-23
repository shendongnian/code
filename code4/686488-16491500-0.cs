    private BindingSource bs = new BindingSource();
    private MyContext context = new MyContext();
    
    context.MyEntities.Where(x=>x.SomeProperty == 2).Load(); 
    bs.DataSource = context.MyEntities.Local.ToBindingList(); 
    myDataGridView.DataSource = bs;
