          var locationOverlay = new MapOverlay
                {
                        Content = new Ellipse()
                                {
                                        Fill = new SolidColorBrush(Colors.Blue),
                                        Height = 20,
                                        Width = 20,
                                        Opacity = 50
                                },
                        PositionOrigin = new Point(0.5, 0.5),
                        GeoCoordinate = placeCoordinate
                };
