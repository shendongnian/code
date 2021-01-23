    public Window4()
        {
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(Window4_Closing);
        }
        void Window4_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }
