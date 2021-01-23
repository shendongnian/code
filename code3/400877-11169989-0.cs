    public List<string> GetTypes()
        {
            NissanDBEntities niss = new NissanDBEntities();
            return niss.cars.Select(m => m.type).Distinct().ToList();
        }
    public Clients()
        {
            InitializeComponent();
            NissanSvc.NissanServiceClient proxy = new Nissan.NissanSvc.NissanServiceClient();
            proxy.GetTypesCompleted += new EventHandler<NissanSvc.GetTypesCompletedEventArgs (proxy_GetTypesCompleted);
            proxy.GetTypesAsync();
        }
        void proxy_GetTypesCompleted(object sender, NissanSvc.GetTypesCompletedEventArgs e)
        {
            this.cmbType.ItemsSource = e.Result;
        }
