    class ShowInfo
    {
        public static void show()
        {
            System.Windows.Forms.MessageBox.Show("test");
        }
    }
...
 
        public Form1()
        {
            InitializeComponent();
            ShowInfo.show();
        }
