    if (userCanAdd)
        container.Controls.Add(GetAddButton());
    if (userCanUpdate)
        container.Controls.Add(GetUpdateButton());
    if (userCanDelete)
        container.Controls.Add(GetDeleteButton());
    private Button GetAddButton() {
        var addButton = new Button();
        // init properties here
        addButton.Click += (s,e) => { /* add logic here */ };
        // addButton.Click += (s,e) => Add();
        // addButton.Click += OnAddButtonClick;
        return addButton;
    }
    private void OnAddButtonClick (object sender, EventArgs e) { 
        // add logic here
    }
    // The other methods are similar to the GetAddButton method.
