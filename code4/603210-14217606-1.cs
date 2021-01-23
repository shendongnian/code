    private void button_Click(object sender, RoutedEventArgs e)
            {
                var test = new LongTask();
                test.MyEvent += test_MyEvent;
                test.Execute();
            }
    
            void test_MyEvent(object sender, EventArgs e)
            {
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    test.Text += " bang ";
                });
    
