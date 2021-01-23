     ThreadPool.QueueUserWorkItem(delegate
     {
        Thread.Slepp(5000);
        MessageBox.Show("Hello");
        Thread.Slepp(5000);
        MessageBox.Show("World");
        Thread.Slepp(5000);      
        MessageBox.Show("Hello World");  
     });
