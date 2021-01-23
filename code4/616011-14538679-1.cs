    private void TextBox1_PreviewKeyUp_1(object sender, KeyEventArgs e)
    {
            TextBox1.Text = "Some other text";
            Dispatcher.BeginInvoke((Action)new Action(() =>
                MessageBox.Show("TextBox1 Width = " + TextBox1.Width + " & TextBox1.ActualWidth = " + TextBox1.ActualWidth)),
              System.Windows.Threading.DispatcherPriority.Input);
    }
