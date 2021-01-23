    ObservableCollection<Class1> p = new ObservableCollection<Class1>();
    public Antocids()
    {
    
        InitializeComponent();
        listBox1.DataContext=p; 
    
         ServiceReference3.ProductsClient client = new ServiceReference3.ProductsClient();
        client.getProdDetailsCompleted += new EventHandler<ServiceReference3.getProdDetailsCompletedEventArgs>(client_getProdDetailsCompleted);
        client.getProdDetailsAsync();
    }
    private void client_getProdDetailsCompleted(object sender, ServiceReference3.getProdDetailsCompletedEventArgs e)
    {
        p.Clear(); // assuming you want to clear the data each time you get a new result 
        foreach(var result in e.Result)
          p.Add(result) // assuming that e.Result holds an IEnumerable of Class1. 
    }
