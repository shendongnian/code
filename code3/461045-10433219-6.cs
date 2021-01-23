    void StartEndValidate(object source, ServerValidateEventArgs args)
    {
        DateTime startDate;
        DateTime endDate;
        bool isStartDate = DateTime.TryParse(txtStartDate.Text, out startDate);
        bool isEndDate   = DateTime.TryParse(txtEndDate.Text, out endDate);
        if(isStartDate && isEndDate)
        {
            int days = (endDate - startDate ).Days;
            args.IsValid = days == 45;
        }
        else
        {
            args.IsValid = false;
        }
    }
