    foreach (TabPage page in Modules.lstTankTabPages)
    {
        PropertyGrid newPropertyGrid = page.Controls.OfType<PropertyGrid>().FirstOrDefault()
        if (newPropertyGrid != null)
        {
            // do something with it
        }
    }
