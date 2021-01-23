    var result = db.Personnels.AsQueryable();
    if (!string.IsNullOrEmpty(txtFirstName.Text))
    {
        if (this.FirstNameFilter != txtFirstName.Text)
        {
            this.FirstNameFilter = txtFirstName.Text;
            e.Arguments.StartRowIndex = 0;
        }
        if (!string.IsNullOrEmpty(this.FirstNameFilter))
        {
            result = result.Where(r => r.First_Name.Contains(txtFirstName.Text));
        }
    }
    if (!string.IsNullOrEmpty(txtLastName.Text))
    {
        if (this.LastNameFilter != txtLastName.Text)
        {
            this.LastNameFilter = txtLastName.Text;
            e.Arguments.StartRowIndex = 0;
        }
        if (!string.IsNullOrEmpty(this.LastNameFilter))
        {
            result = result.Where(r => r.First_Name.Contains(txtLastName.Text));
        }
    }
    e.Arguments.TotalRowCount = result.Count();
    e.Result = result;
