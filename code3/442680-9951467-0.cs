		private void buttonTest_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.RightButton == MouseButtonState.Pressed)
			{
				MessageBox.Show("Right");
			}
			else if (e.LeftButton == MouseButtonState.Pressed)
			{
				MessageBox.Show("Left");
			}
			e.Handled = true;
		}
