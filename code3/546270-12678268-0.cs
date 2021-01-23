    public MainWindow()
    {
        InitializeComponent();
        System.Threading.Thread thread = new System.Threading.Thread(
            new Action(() => ChangePoints(polyline)));
        thread.Start();
    }
    private void ChangePoints(Polyline p)
    {
        // Create once and reuse
        Random random = new Random();
        while (true)
        {
            PointCollection points = new PointCollection();
            for (int i = 0; i < 500; i += 10)
            {
                points.Add(new Point(i, random.Next(1, 300)));
            }
            // Now marshal back to the UI thread here...
            Dispatcher.Invoke(DispatcherPriority.Normal, 
                new Action( () => p.Points = points));
            // Optionally delay a bit here...
            Thread.Sleep(250);
        }
    }
