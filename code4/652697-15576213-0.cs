    private void ChangeXaml()
    {
        var reader = new StringReader(xamlToReplaceStuffWith);
        var xmlReader = XmlReader.Create(reader);
        var newWindow = XamlReader.Load(xmlReader) as Window;    
        newWindow.Show();
        foreach(var prop in typeof(Window).GetProperties())
        {
            if(prop.CanWrite)
            {
                try 
                {
                    // A bunch of these will fail. a bunch.
                    Console.WriteLine("Setting prop:{0}", prop.Name);
                    prop.SetValue(this, prop.GetValue(newWindow, null), null);
                } catch
                {
                }
            }
        }
        newWindow.Close();
        this.InvalidateVisual();
    }
