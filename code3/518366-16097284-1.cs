        private void myTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text.Trim() == "")
            {
                ((ToolTip)tb.ToolTip).Visibility = Visibility.Hidden;
            }
            else
            {
                toolTipTextBlock.Text = tb.Text;
                ((ToolTip)tb.ToolTip).Visibility = Visibility.Visible;
            }
        }
