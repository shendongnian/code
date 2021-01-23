    public MainWindow : Window
    {
          private void ShowWindow1()
          {
              var window1 = new Window1();
              window1.btnRetry.Click += OnRetryClicked;
              window1.ShowDialog();
          }
          private void OnRetryClicked(object sender, EventArgs e)
          {
             // will be called when window1.btnRetry is clicked.
             // retry the connection.
             Connect();
          }
    }
