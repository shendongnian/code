     ThreadPool.QueueUserWorkItem(delegate
     {
        Thread.Sleep(5000);
        MessageBox.Show("Hello");
        Thread.Sleep(5000);
        MessageBox.Show("World");
        Thread.Sleep(5000);      
        MessageBox.Show("Hello World");  
     });
