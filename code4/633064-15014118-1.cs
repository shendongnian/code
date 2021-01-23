		bool isDragging = false;
		private void splitter_MouseDown_1(object sender, MouseButtonEventArgs e)
		{
			isDragging = true;
		}
		private void Window_MouseMove_1(object sender, MouseEventArgs e)
		{
			if(isDragging)
			splitter.Margin = new Thickness(0, e.GetPosition(this).Y,0,0);
		}
		private void Window_MouseUp_1(object sender, MouseButtonEventArgs e)
		{
			isDragging = false;
		}
