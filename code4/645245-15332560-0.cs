    var bc = new BackgroundWorker();
        // showing only completed event handling , you need to handle other events also
            bc.RunWorkerCompleted += delegate
                                         {
                                            _dispatcher.Invoke(() => { 
                                            //Enable the Explore link to verify the package
                                            BuildExplorer.Visibility = Visibility.Visible;
                                         };
