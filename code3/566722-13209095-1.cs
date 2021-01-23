    if (Page.PreviousPage != null)
    {
        if (Page.PreviousPage is PreviousPageClassName)
        {
            Label1.Text = ((PreviousPageClassName)Page.PreviousPage).TextFromBox1;
        }
        else
        {
            Label1.Text = "no value";
        }
    }
    else
        Label1.Text = "no value from previous page";
