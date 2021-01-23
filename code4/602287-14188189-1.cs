    private void reDraw()
            {
                 Task<IList<Point>> calculatePointTask = Task.Factory.StartNew(() =>
                {
                    //Use the list of points instead of thread-bound PointCollection
                    IList<Point> pointCollection = new List<Point>();
                    //Simulating that we calculate points
                    Thread.Sleep(3000);
                    pointCollection.Add(new Point(10,20));
                    pointCollection.Add(new Point(10,20));
                    return pointCollection;
                });
            calculatePointTask.ContinueWith(ante =>
                {
                    
                    var calculatedPoints = calculatePointTask.Result;
                    Action<IList<Point>> updateUI = (points) =>
                        {
                            var pointCollection = new PointCollection(points);
                            polyline.Points = pointCollection;
                        };
                    Application.Current.Dispatcher.Invoke(updateUI, calculatedPoints);
                }, TaskContinuationOptions.AttachedToParent);
            }
