    private void launchViewerThread_Click(object sender, RoutedEventArgs e)
    {
        Thread viewerThread = new Thread(delegate()
        {
            viewer = new SkeletalViewer.MainWindow();
            viewer.Show();
            System.Windows.Threading.Dispatcher.Run();
        });
        viewerThread.SetApartmentState(ApartmentState.STA); // needs to be STA or throws exception
        viewerThread.Start();
    }
