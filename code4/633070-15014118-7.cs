	FrameworkElement dragginSplitter = null;
	private void splitter_MouseDown_1(object sender, MouseButtonEventArgs e)
	{
		dragginSplitter = sender as FrameworkElement;
	}
	private void Window_MouseMove_1(object sender, MouseEventArgs e)
	{
		if (dragginSplitter != null)
		{
			dragginSplitter.Margin = new Thickness(0, e.GetPosition(this).Y, 0, 0);
			updateSplitters();
		}
	}
	private void updateSplitters()
	{
		if (splitter2.Margin.Top < splitter1.Margin.Top + 10) splitter2.Margin = new Thickness(0, splitter1.Margin.Top + 10, 0, 0);
		if (splitter3.Margin.Top < splitter2.Margin.Top + 10) splitter3.Margin = new Thickness(0, splitter2.Margin.Top + 10, 0, 0);
		if (check1.IsChecked.Value)
		{
			if (!check2.IsChecked.Value && !check3.IsChecked.Value && !check4.IsChecked.Value)
				row1.Height = new GridLength(1, GridUnitType.Star);
			else 
				row1.Height = new GridLength(splitter1.Margin.Top);
		}
		else
			row1.Height = new GridLength(0);
		if (check2.IsChecked.Value)
		{
			if (!check3.IsChecked.Value && !check4.IsChecked.Value)
				row2.Height = new GridLength(1, GridUnitType.Star);
			else if(check1.IsChecked.Value)
				row2.Height = new GridLength(splitter2.Margin.Top - splitter1.Margin.Top);
			else
				row2.Height = new GridLength(splitter2.Margin.Top);
		}
		else
			row2.Height = new GridLength(0);
		if (check3.IsChecked.Value)
		{
			if (!check4.IsChecked.Value)
				row3.Height = new GridLength(1, GridUnitType.Star);
			else if (check2.IsChecked.Value)
				row3.Height = new GridLength(splitter3.Margin.Top - splitter2.Margin.Top);
			else if (check1.IsChecked.Value)
				row3.Height = new GridLength(splitter3.Margin.Top - splitter1.Margin.Top);
			else
				row3.Height = new GridLength(splitter3.Margin.Top);
		}
		else
			row3.Height = new GridLength(0);
		row4.Height = check4.IsChecked.Value ? new GridLength(1, GridUnitType.Star) : new GridLength(0);
	}
	private void Window_MouseUp_1(object sender, MouseButtonEventArgs e)
	{
		dragginSplitter = null;
	}
	private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
	{
		if (check4 == null) return;//for when not yet completely loaded
		if (!check1.IsChecked.Value)
			splitter1.Visibility = System.Windows.Visibility.Collapsed;
		if (!check2.IsChecked.Value)
			splitter2.Visibility = System.Windows.Visibility.Collapsed;
		if (!check3.IsChecked.Value)
			splitter3.Visibility = System.Windows.Visibility.Collapsed;
		if (!check4.IsChecked.Value)
		{
			splitter3.Visibility = System.Windows.Visibility.Collapsed;
			if (!check3.IsChecked.Value)
				splitter2.Visibility = System.Windows.Visibility.Collapsed;
			if (!check2.IsChecked.Value)
				splitter1.Visibility = System.Windows.Visibility.Collapsed;
		}
		if (check1.IsChecked.Value && (check2.IsChecked.Value || check3.IsChecked.Value || check4.IsChecked.Value))
			splitter1.Visibility = System.Windows.Visibility.Visible;
		if (check2.IsChecked.Value && (check3.IsChecked.Value || check4.IsChecked.Value))
			splitter2.Visibility = System.Windows.Visibility.Visible;
		if (check3.IsChecked.Value && check4.IsChecked.Value)
			splitter3.Visibility = System.Windows.Visibility.Visible;
		updateSplitters();
	}
