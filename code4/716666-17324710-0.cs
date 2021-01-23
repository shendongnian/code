        private void ChangeResource_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan MyTimespan = new TimeSpan(2, 2, 3);
            Duration DurationInCode = MyTimespan;
            // Set the new value
            Application.Current.Resources["MyDuration"] = MyTimespan;
            // Show value
            MyTextBlock.Text = Application.Current.Resources["MyDuration"].ToString();
        }
