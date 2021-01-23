    Tutorial tutorial = ListBox.SelectedItem as Tutorial;
    if(tutorial == null) return;
    
    var item = Application.GetResourceStream(new Uri(tutorial.Location, UriKind.Relative));
    using (Stream Text = Tutorial.Stream)
    {
        StreamReader sr = new StreamReader(Text);
        Guide.Text = tutorial.Prefix + sr.ReadToEnd();
        Title.Text = tutorial.Tile;
        AppBarMenuDisable.IsEnabled = false;
    }
