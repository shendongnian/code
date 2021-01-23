    public void createAudioNotetaker()
    {
        //this button click event works
        btnAudioNotetaker.Click += commonClickHandler;
    }
    
    public void createClaroRead()
    {
        //this one doesn't work
        btnClaroRead.Click += commonClickHandler;
    }
    
    void commonClickHandler(object sender, EventArgs e)
    {
        btnModule_Click(sender, e, audioNotetakerDict, videoPathDict, pdfPathDict, audioPathDict));
    } 
    void btnModule_Click(object sender, EventArgs e, OrderedDictionary pageContent, OrderedDictionary videoPathDict, OrderedDictionary pdfPathDict, OrderedDictionary audioPathDict)
    {
        //i want to use this event for each button
        ModuleTemplate newForm = new ModuleTemplate(pageContent, videoPathDict, pdfPathDict, audioPathDict);
        newForm.Show();
        this.Hide();
    }
