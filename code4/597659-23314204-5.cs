            // Set up notifications list
            listViewNotifications.SetBinding(ListView.ItemsSourceProperty, new Binding { Source = _activeNotifications });
            listViewNotifications.Tapped += listViewNotifications_Tapped;
            Grid.SetRowSpan(listViewNotifications, 2);
            Grid.SetColumnSpan(listViewNotifications, 2);
            var xamlString =
                "<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">" +
                    "<StackPanel Orientation=\"Horizontal\" VerticalAlignment=\"Center\">" +
                        "<TextBlock Text=\"{Binding Name}\" Margin=\"20,0,10,0\"/>" +
                        "<TextBlock Text=\"{Binding Type}\" Margin=\"0,0,10,0\"/>" +
                        "<TextBlock Text=\"{Binding DayOfWeek}\" Margin=\"0,0,10,0\"/>" +
                        "<TextBlock Text=\"{Binding DeliveryTime}\" Margin=\"0,0,10,0\"/>" +
                        "<TextBlock Text=\"{Binding Id}\"/>" +
                    "</StackPanel>" +
                "</DataTemplate>";
            var dataTemplate = (DataTemplate)XamlReader.Load(xamlString);
            listViewNotifications.ItemTemplate = dataTemplate;
            GridMain.Children.Add(listViewNotifications);
