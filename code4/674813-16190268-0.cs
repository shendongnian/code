    private void button1_Click(object sender, RoutedEventArgs e)
        {
            jomarzi.ServiceSoapClient obj = new jomarzi.ServiceSoapClient();
            obj.HelloWorldCompleted +=new EventHandler<jomarzi.HelloWorldCompletedEventArgs>(obj_HelloWorldCompleted);
            obj.HelloWorldAsync();
        }
        private void obj_HelloWorldCompleted(object sender, jomarzi.HelloWorldCompletedEventArgs e)
        {
            textBlock1.Text = e.Result;
        }
