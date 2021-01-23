    private void mnuBack_ItemClick(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            Label l = new Label();
            canBackArea.Children.Add(l);
            l.Visibility = System.Windows.Visibility.Visible;
            l.Content = "Hello";
            Canvas.SetLeft(l, 20);
            Canvas.SetTop(l, 20);
            Canvas.SetZIndex(l, lableList.Count);
            lableList.Add(l);
        }
