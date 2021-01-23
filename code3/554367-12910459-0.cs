    AutoCompleteStringCollection data = new AutoCompleteStringCollection();
    data.Add("Mahesh Chand");
    data.Add("Mac Jocky");
    data.Add("Millan Peter");
            
    // Create and initialize the text box
    var prodCode = new TextBox
    {
       AutoCompleteCustomSource = data,
       AutoCompleteMode = AutoCompleteMode.SuggestAppend,
       AutoCompleteSource = AutoCompleteSource.CustomSource,
       Location = new Point(20, 20),
       Width = ClientRectangle.Width - 40,
       Visible = true
    };
