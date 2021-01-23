		private void Chart_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
		{
            Series serie = sender as Series;
            DateTime xAxisValue;
            Point p = e.GetPosition(serie);
            ICategoryAxis xAxis = (CategoryAxis)Chart.ActualAxes[0];
            object xHit = xAxis.GetCategoryAtPosition(new UnitValue(p.X, Unit.Pixels));
            if (SelectedObj != null)
            {
                xAxisValue = (DateTime)new DateTimeConverter().ConvertBack(xHit as String, typeof(String), SelectedObj.DisplayFrequency, Thread.CurrentThread.CurrentUICulture);
                foreach (Frequency frequency in SelectedObj.Frequencies)
                {
                    if(frequency == SelectedObj.DisplayFrequency)
                        addMenuItem(frequency, true, xAxisValue);
                    else
                        addMenuItem(frequency, false, xAxisValue);
                }
                    
                cMenu.IsOpen = true;
                cMenu.HorizontalOffset = e.GetPosition(LayoutRoot).X;
                cMenu.VerticalOffset = e.GetPosition(LayoutRoot).Y;
            }
		}
        private void addMenuItem(Frequency frequency, bool isDisplayFrequency, DateTime xAxisValue)
        {
            menuItem = new MenuItem();
            menuItem.Header = frequency;
            menuItem.Tag = xAxisValue;
            if (isDisplayFrequency)
            {
                menuItem.Icon = new TextBlock { Text = "\xfc", FontFamily = new System.Windows.Media.FontFamily("Wingdings"), FontWeight = FontWeights.Bold, TextAlignment = TextAlignment.Center };
                menuItem.FontWeight = FontWeights.Bold;
            }
            cMenu.Items.Add(menuItem);
            menuItem.Click += new RoutedEventHandler(menuItem_Click);
        }
        void menuItem_Click(object sender, RoutedEventArgs e)
        {
			MenuItem item = sender as MenuItem;
			Frequency itemFreq = (Frequency)item.Header;
            DateTime xAxisValue = (DateTime)item.Tag;
            ...
			cMenu.IsOpen = false;
		}
