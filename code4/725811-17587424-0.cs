    public async void Page_Load(object sender, EventArgs e)
    {
        using(var MyDumpEntities = new MyDumpEntities())
        {
           var data = await MyDumpEntities.AgeGroups.ToListAsync();
        }     
    }
