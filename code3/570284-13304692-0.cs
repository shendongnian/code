            var btntab = new Button();
            var tbGoToNextTab = new TextBlock();
            tbGoToNextTab.Text = "Please Click Here to go to next Page.";
            tbGoToNextTab.Foreground = new SolidColorBrush(Colors.Black);
            btntab.Click += new RoutedEventHandler(btntab_Click);
            btntab.Content = tbGoToNextTab;
            Text112.Children.Add(btntab);
