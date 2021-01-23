    private void button1_Click(object sender, RoutedEventArgs e)
            {
                label1.Text = "first";
                Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle);
                Thread.Sleep(1000);                            
               label1.Text = "second";
        }
