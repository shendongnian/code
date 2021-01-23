    if (_dataX[i].Length == _dataY[i].Length)
                        {
                            EnumerableDataSource<int> xOneCh = new EnumerableDataSource<int>(_dataX[i]);
                            xOneCh.SetXMapping(xVal => xVal);
                            EnumerableDataSource<int> yOneCh = new EnumerableDataSource<int>(_dataY[i]);
                            yOneCh.SetYMapping(yVal => yVal);
                            CompositeDataSource ds = new CompositeDataSource(xOneCh, yOneCh);
    
                            Action UpdateData = delegate()
                            {
                              
                                ((PointsGraphBase)plotter.Children.ElementAt(startIndex + i + 1)).DataSource = ds; 
                              
                            };
                        this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, UpdateData);
                    }
