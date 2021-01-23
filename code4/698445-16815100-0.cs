    var radius = 100;
    var angle = 360 / itmeList.Count * Math.PI / 180.0f;
    var center = new Point(100, 100);
    for (int i = 0; i < itemList.Count; i++)
                {
                    var x = center.X +  Math.Cos(angle * i) * radius;
                    var y = center.Y +  Math.Sin(angle * i) * radius;
                    Button newButton = new Button();
                    newButton.RenderTransformOrigin = new Point(x, y);
                    newButton.Height = 50;
                    newButton.Width = 50;
                    newButton.Content = a.getName();
                    newButton.Click += new RoutedEventHandler(addedClick);
                    newButton.HorizontalAlignment = HorizontalAlignment.Left;
                    newButton.VerticalAlignment = VerticalAlignment.Top;
                    newButton.Margin = new Thickness(0, 0, 0, 0);
                    newButton.Style = (Style)Application.Current.Resources["RB"];
                    buttons.Add(newButton);
                }
