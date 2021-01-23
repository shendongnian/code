    private void Button_Click_3(object sender, RoutedEventArgs e)
    {
        var file = await ApplicationData.Current.LocalFolder.GetFileAsync(textbox1.Text + ".txt");
        var line = await FileIO.ReadLinesAsync(file);
        if (textbox1.Text == line[0] && tb2.Password == line[1])
        {
            textbox1.Text = line[0];
            Frame.Navigate(typeof(form2), textbox1.Text);                    
        }
    }
