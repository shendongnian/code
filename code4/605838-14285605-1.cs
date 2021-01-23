    DispatcherTimer currentSpeedTimer = new DispatcherTimer();
                currentSpeedTimer.Interval = new TimeSpan(0, 0, 1);
                currentSpeedTimer.Tick += (sender, e) =>
                {
                    if (this.GeoCoordinateWatcher.Position.Location.HorizontalAccuracy < 10)
                    {
                        if (DateTime.Now - this.GeoCoordinateWatcher.Position.Timestamp.DateTime > new TimeSpan(0, 0, 2))
                        {
                            CurrentSpeed = 0;
                        }
                        else
                        {
                            CurrentSpeed = double.IsNaN(this.GeoCoordinateWatcher.Position.Location.Speed) ? 0 : this.GeoCoordinateWatcher.Position.Location.Speed;
                        }
                    }
                };
                currentSpeedTimer.Start();
