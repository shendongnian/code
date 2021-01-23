        for (int i = 0; i < n; i++) {
            int number = i;
            buttons[i].Click += (sender, args) => OnButtonClick(sender, args, number);
        }
    ...
        private void OnButtonClick(object sender, RoutedEventArgs e, int number) {
            MessageBox.Show(number.ToString(CultureInfo.InvariantCulture));
        }
