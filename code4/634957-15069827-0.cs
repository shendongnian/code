    public Form1()
    {
       this.Load += OnLoad();
       this.FormClosing += OnFormClosing();
    }
    private void OnLoad(object sender, EventArgs e)
    {
       // Read Data from Xml with the dataset (dataset.Readxml...)
    }
    private void OnFormClosing(object sender, FormClosingEventArgs e)
    {
       // Write the Data from the textboxes into the xml (dataset.writexml...)
    }
