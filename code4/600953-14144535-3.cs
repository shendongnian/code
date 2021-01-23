    DateTime? dateOfService= null;
    if (string.IsNullOrEmpty(txtb_dateOfService.Text))
    {
        dateOfService = null;
    }
    else
    {
        DateTime temp;
        if (DateTime.TryParse(txtb_dateOfService.Text, out temp))
        {
            dateOfService = temp;
        } 
        else 
        {
            dateOfService = null;
        }
    }
