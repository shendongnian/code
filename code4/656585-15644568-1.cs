    //private fields
    private readonly DBContext _dbContext = new DBContext();
    private Task<ICollection<string>> GetValues1()
    {
        return Task.Run(() =>
                {
                    return (from i in _dbContext.Items
                            where i.Value1 != null
                            && i.Value1.Length > 0
                            orderby i.Value1
                            select i.Value1)
                            .Distinct()
                            .ToList();
                 };
    }
    private async Task LoadValues1(ICollection<string> values)
    {
        var observableValues = new ObservableCollection<string>(values);
        
        lookupValues1.Properties.DataSource = descModelYear;
        DevExpress.XtraEditors.Controls.LookUpColumnInfoCollection colInfo = lookupValues1.Properties.Columns;
        colInfo.Clear();
        colInfo.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Column"));
        colInfo[0].Caption = "Values 1";
    }
    private async void form1_Load(object sender, EventArgs e)
    {
        var tasks = new List<Task>();
        // Start each UI task so they will complete independently.
        var uiTask1 =  GetValues1()
              .ContinueWith(t =>
                    LoadUIElements1(t.Result),
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskScheduler.FromCurrentSynchronizationContext());
        tasks.Add(uiTask1);
        
        // Wait for all the tasks to complete
        Task.WaitAll(tasks.ToArray());
        tasks.Clear();
    }
