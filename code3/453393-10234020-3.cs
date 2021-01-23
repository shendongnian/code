    private void Button_Click(object sender, RoutedEventArgs e)
		{
			var sum = 0.0;
			for (int i = 1; i < grid.Children.Count; i++ )
			{
				var textBox = grid.Children[i] as TextBox;
				if (textBox == null) continue;
				double value;
				Double.TryParse(textBox.Text, out value);
				sum += value;
			}
			Console.WriteLine(sum);
		}
