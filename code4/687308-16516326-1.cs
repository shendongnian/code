        //Gets all checkbox's on the form
        List<CheckBox> chks = Controls.OfType<CheckBox>().ToList();
        
        //take only those who is checked, and select only their name property
        List<string> names = chks.Where(c => c.Checked).Select(c => c.Name);
