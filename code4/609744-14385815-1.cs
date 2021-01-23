    private ImageBrush m_Background = new ImageBrush();
    private void button_Click(object sender, RoutedEventArgs e) 
    {
        // If actorUri is stored in a TextBox, for example...
        random(textbox1.Text);
    }
    private void random(String actorUri)
    {
        // ...
        m_Background = new ImageBrush();
        m_Background.ImageSource = new BitmapImage(new Uri(actorUri, UriKind.Relative));
        // ...
    }
