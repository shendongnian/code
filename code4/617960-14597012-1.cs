       private void SelectQualityChecked(object sender, RoutedEventArgs e)
        {
            txtSelectedQuantity.IsEnabled = SelectQuality.Checked;
            txtSelectedQuantity.Focusable = SelectQuality.Checked;
            if(SelectQuality.Checked)
            {
                txtSelectedQuantity.Focus();
            }
        }
