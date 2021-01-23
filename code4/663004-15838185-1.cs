     var img = new Image {Width = 100, Height = 100};
     var bitmapImage= new BitmapImage (new Uri(@"pack://application:,,,/Images/old-go-down.png"));
           
     img.Source = bitmapImage;
     img.SetValue(Grid.RowProperty, 1);
     img.SetValue(Grid.ColumnProperty, 1);
            
     paretoGrid.Children.Add(img);
