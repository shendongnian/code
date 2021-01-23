    public partial class DB_conn_win : Window 
    { 
 
        private void ask_DB_Click(object sender, RoutedEventArgs e) 
        { 
            this.Query = textBox1.Text(); 
        } 
        public string Query;
    ..... 
    } 
    public partial class MainWindow : Window 
    { 
 
      string DB_query = DB_conn_win.query; 
  
      public SomeButton_Click(object sender, RoutedEventArgs e)
      {
         var dialog = new DB_conn_win();
         if (dialog.ShowDialog() == true)
         {
           this.DB_query = dialog.Query;
         }
      }
