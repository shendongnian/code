     public MainPage()
            {
                InitializeComponent();
                if (CreateStore().FileExists("Userdata\\Userdata.txt"))
                {
                    mail.Text = ReadFile(CreateStore()); //opens file and never closes it.
                }
            }
