    private void scannedString_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((sender as TextBox).Text !="" && e.Key == Key.Return)
            {
                MessageBox.Show((sender as TextBox).Text); // I mean do some thing
                (sender as TextBox).Clear();
            }
        }
