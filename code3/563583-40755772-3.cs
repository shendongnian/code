        public MainWindow()
        {
            InitializeComponent();
            //Give the Source to ListViewTest
            //ProduceNames() makes a List<NameClass> that 
            //NameClass has 3 property Name1,Name2,Nmae3
            ListViewTest.ItemsSource = ProduceNames();
            GridView gview = new GridView();
            //add some GridViewColumns to the gview
            gview.Columns.Add(NewGridViewColumn("FirstName","Name1"));
            gview.Columns.Add(NewGridViewColumn("SecondName","Name2"));
            gview.Columns.Add(NewGridViewColumn("ThirdName","Name3"));
            //set the gview to the ListViewTest's View
            ListViewTest.View = gview;
        }
