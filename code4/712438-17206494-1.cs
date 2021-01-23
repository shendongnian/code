      public MainWindow()
            {
                Random r = new Random();
                InitializeComponent();
                for (int i = 0; i < 10; i++)
                {
                    myList.Items.Add(new { Name = "Name" + i.ToString(), Online = Convert.ToBoolean(r.Next(-1, 1)) });
                }
            }
