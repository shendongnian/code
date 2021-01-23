    private void Button_Click( object sender, RoutedEventArgs e ) {
        MainWindow w = new MainWindow( );
        this.Close( );
        DispatcherTimer timer = new DispatcherTimer( );
        timer.Interval = new TimeSpan( 0, 0, 3 );
        timer.Tick += ( o, a ) => {
            ( (DispatcherTimer)o ).Stop( );
            w.Show( ); 
        };
        timer.Start( );
    }
