     Action UpdateData = delegate()
                            {
                                ((LineGraph)plotter.Children.ElementAt(startIndex + i)).DataSource = ds;
                                ((LineGraph)plotter.Children.ElementAt(startIndex + i)).LinePen = new Pen(new SolidColorBrush(Colors.Green), 1);
    
                                ((PointsGraphBase)plotter.Children.ElementAt(startIndex + i + 1)).DataSource = ds;
                                ((MarkerPointsGraph)plotter.Children.ElementAt(startIndex + i + 1)).Marker = new CirclePointMarker { Size = 5, Fill = Brushes.Red };                 
                            };
    
                            this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, UpdateData);
