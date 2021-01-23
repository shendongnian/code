		FrameworkElement dragginSplitter = null;
		private void splitter_MouseDown_1(object sender, MouseButtonEventArgs e)
		{
			dragginSplitter = sender as FrameworkElement;
		}
		private void Window_MouseMove_1(object sender, MouseEventArgs e)
		{
			if (dragginSplitter != null)
				dragginSplitter.Margin = new Thickness(0, e.GetPosition(this).Y, 0, 0);
			if (splitter2.Margin.Top < splitter1.Margin.Top + 10) splitter2.Margin = new Thickness(0, splitter1.Margin.Top + 10, 0, 0);
			if (splitter3.Margin.Top < splitter2.Margin.Top + 10) splitter3.Margin = new Thickness(0, splitter2.Margin.Top + 10, 0, 0);
			row1.Height = new GridLength(splitter1.Margin.Top);
			row2.Height = new GridLength(splitter2.Margin.Top - splitter1.Margin.Top);
			row3.Height = new GridLength(splitter3.Margin.Top - splitter2.Margin.Top);
		}
		private void Window_MouseUp_1(object sender, MouseButtonEventArgs e)
		{
			dragginSplitter = null;
		}
