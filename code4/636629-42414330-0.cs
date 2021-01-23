        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
           new Suucessfullogin(textboxvalue.text).ShowDialog();
        }
   }
    in second window we can get value
    public partial class Suucessfullogin : Window
    {
          string str;   
        public Suucessfullogin(string value)
        {
            InitializeComponent();
            str= value;     
        }
    }
