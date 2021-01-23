    private void button4_Click(object sender, RoutedEventArgs e)
    {
        string site;
        site = textBox1.Text;
        webBrowser1.Navigate(
             new Uri(System.String.Format("http://m.bing.com/search?q={0}", site), UriKind.Absolute));
