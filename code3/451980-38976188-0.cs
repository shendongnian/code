    public partial class MainWindow : Window
    {
        string un;
        string pw;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            un = txtName.Text;
            pw = txtPw.Text;
            if (un.Equals("steve") && pw.Equals ("cool"))
            {
                Home h= new Home();
                this.Content = h.Content; ***// this is where we change the window's contents***
              
               
            }
        }
    }
}
