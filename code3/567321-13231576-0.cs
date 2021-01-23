    private void button1_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                 
                 this.Dispatcher.BeginInvoke((Action)(() =>
                 {
                     SocketMe sc = new SocketMe();
                     sc.socketStart();
                     // etc...
                 }));
            }
        }
