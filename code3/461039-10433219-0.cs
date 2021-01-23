    void ServerValidation (object source, ServerValidateEventArgs args)
    {
        var startDate = DateTime.Parse(txtStartDate.Text);
        var endDate = DateTime.Parse(txtEndDate.Text);
        var days = (endDate - startDate ).Days;
        args.IsValid = days == 45;
    }
