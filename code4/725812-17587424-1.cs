    public async void Page_Load(object sender, EventArgs e)
    {
        using(var MyDumpEntities = new DumpEntities1())
        {
           var data = await MyDumpEntities.AgeGroups.ToListAsync();
        }     
    }
