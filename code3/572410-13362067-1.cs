    bool inputOk = false;
    try
    {
        try
        {
            int y = int.Parse(yearTextBox.Text);
            int m = int.Parse(monthTextBox.Text);
            int d = int.Parse(dayTextBox.Text);
            inputOk = true;
        }
        catch
        {
            Debug.Writeline("Invalid input");
        }
        if(inputOk)
        {
            DateTime value = new DateTime(y, m, d);
            Debug.Writeline("It's a valid date");
        }
    }
    catch
    {
        Debug.Writeline("It isn't a valid date");
    }
