    public static void ApplySettings(this Button button, XDocument xdoc)
    {
        var settings = xdoc
                     .Descendatns("Button")
                     .SingleOrDefault(b => (string)b.Element("Name") == button.Name);
    
        if (settings == null)
           return;
    
        button.Text = (string)settings.Element("Text");
        var location = settings.Element("Location");
        if (location != null)
        {
            button.X = (int)location.Element("X");
            button.Y = (int)location.Element("Y");
        }
        
        //etc
    }
