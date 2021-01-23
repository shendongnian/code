    private void txtCurrentPage_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
    
            if (tb != null)
            {
                DocumentViewerReading.GoToPage(Convert.ToInt32(tb.Text));
            }
        }
