    void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (double x = 0; x < 10000000000; )
            {
                x++;
            }
        }
        private void test_Click(object sender, RoutedEventArgs e)
        {
            test.Background = Brushes.Orange;
            worker.RunWorkerCompleted += (_,__) =>  test.Background = Brushes.Red; 
            worker.RunWorkerAsync();
            
        }
