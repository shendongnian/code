    public partial class DB_conn_win : Window { 
        public string query;
        private void ask_DB_Click(object sender, RoutedEventArgs e) { 
            this.query = textBox1.Text(); 
        } 
    }
    
    public partial class MainWindow : Window {
        string DB_query;
        public MainWindow() {
            InitializeComponent();
            Loaded += Window_Loaded;
        }
        void Window_Loaded(object sender, RoutedEventArgs e) {
            DB_conn_win dialog = new DB_conn_win();
            dialog.Owner = this;
            dialog.ShowDialog();
            if (dialog.DialogResult != null && dialog.DialogResult.Value)
                DB_Query = dialog.query;
         }   
    }
