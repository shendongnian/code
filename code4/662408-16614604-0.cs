    private void MyWebBrowser_LoadCompleted_1(object sender, NavigationEventArgs e)
    {
        try
        {
            MyTextBox.Text = MyWebBrowser.Source.ToString();
            Title_doc.Content = ((dynamic)MyWebBrowser.Document).Title;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
