    Random random = new Random();
    Task.Factory.StartNew(() =>
    {
        for (int i = 0; i < 50; i++)
        {
            Thread.Sleep(500);
            Dispatcher.Invoke(DispatcherPriority.Render, new Action(() =>
            {
                Path f = FlowerFactory.createFlower(FlowerBP, true);
                Canvas.SetLeft(f, random.Next(0, 1650));
                Canvas.SetTop(f, random.Next(0,1000));
                DrawBoard.Children.Add(f);
            }));
        }
    });
