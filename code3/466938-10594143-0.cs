    public partial class MainWindow : Window
    {
       private void Window_Loaded(object sender, RoutedEventArgs e)
       {
            var start = new Action<HttpRequestEventArgs>(Start);
            Dispatcher.start(start,e); //start thread
       }
       private void Start(HttpRequestEventArgs e)
       {
            var server = new HttpServer();
            server.EndPoint = new IPEndPoint(127.0.0.0, 80); //set webServer para
            server.Start(); //start webServe
            server.RequestReceived += server_RequestReceived; //register the event
       }
       private void server_RequestReceived(object sender, HttpRequestEventArgs e)
       {
           StreamReader sr = new StreamReader(@"c:\test.txt");
           string text = sr.ReadToEnd();
           using (var writer = new StreamWriter(e.Response.OutputStream)) //**Cannot write stream**
           {
               writer.Write(text);
           }
           sr.Close();
       }
    }
