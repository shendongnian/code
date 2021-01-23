    new Thread(() =>
                {
                    while (_running)
                    {
                        Thread.Sleep(20);
    
                        canvas.Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(() =>
                        {
                            var position = Mouse.GetPosition(canvas).X;
                            var canvasWidth = canvas.ActualWidth;
    
                            if (position >=0 && position < 10.0d)
                                btn.SetValue(Canvas.LeftProperty, (double)btn.GetValue(Canvas.LeftProperty) + 1);
    
                            if (position <= canvasWidth && position > canvasWidth - 10.0d)
                                btn.SetValue(Canvas.LeftProperty, (double)btn.GetValue(Canvas.LeftProperty) - 1);
                        }));
                    }
                }).Start();
