    private void Button_Click(object sender, RoutedEventArgs e)
		{
			var sum = 0.0;
			foreach (var child in stackPanel.Children)
			{
				var textBox = child as TextBox;
				if (textBox == null) continue;
				double value;
				Double.TryParse(textBox.Text, out value);
				sum += value;
			}
			Console.WriteLine(sum);
		}
