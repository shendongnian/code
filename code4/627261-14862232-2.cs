    void Repeater_ItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "ShowAnswers")
        {
            Control control;
            control = e.Item.FindControl("Answers");
            if (control != null)
                control.Visible = true;
            control = e.Item.FindControl("Date");
            if (control != null)
                control.Visible = true;
        }
    }
