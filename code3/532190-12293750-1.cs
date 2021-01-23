    using System.Threading;
    using System.Threading.Tasks;
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
            Task TWorkOnFTP = new TaskFactory().StartNew(ConnectFtp);
    }
    
    private void ConnectFtp()
    {
         // Here i'm connecting to a ftp server. 
         // Do some I/O operation
         // Now time to update UI controls so we invoke on Dispatcher UI thread
         Dispatcher.Invoke(new Action(() =>
         {
             lblMessage.Text = "Process finished";
             // Some other UI updates..
         }));
    }
