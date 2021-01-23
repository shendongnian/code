        public Main()
        {
            InitializeComponent();
            //Create Directory
            sFunctions.CreateDirectory("Pictures");
            ClassConnections conn = new ClassConnections();
            conn.setConnection(
              AppDomain.CurrentDomain.BaseDirectory + "\\Database\\",
              "MasterFile.mdb",
              "lib2006");
            publicMainForm = this;
        }
