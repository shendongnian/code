    // get user input count from the textbxo
    string countString = MyTextBox.Text;
    int count = 0;
    // attempt to convert to a number
    if (int.TryParse(countString, out count))
    {
        // you would probably also want to validate the number is
        // in some range, like 1 to 100 or something to avoid
        // DDOS attack by entering a huge number.
        // create as many labels as number user entered
        for (int i = 1; i <= count; i++)
        {
            // setup label and add them to the page hierarchy
            Label lbl = new Label();
            lbl.ID = "label" + i;
            lbl.Text = "The Label Text.";
            MyParentControl.Controls.Add(lbl);
        }
    }
    else
    {
        // if user did not enter valid number, show error message
        MyLoggingOutput.Text = "Invalid number: '" + countString + "'.";
    }
