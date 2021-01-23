    private void PropertiesButton_Click(object sender, EventArgs e)
    {
    TabPageLibrary library = new TabPageLibrary();
    TabPage propertyPage = library.PropertyPage;
    this.tabControl.TabPages.Add(propertyPage);
    }
