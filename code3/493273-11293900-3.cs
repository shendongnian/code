    button3.Click += (_, __) => SubmitForm();
    private void SubmitForm(object sender, EventArgs e)
    {
        //do submission stuff
        Rebind();
    }
    private void Rebind()
    {
        GatherInfo();
        UpdateTextLabel();
        UpdateTitles();
    }
