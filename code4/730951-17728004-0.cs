    private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
    {
        // gcLink is your column using repositoryitemhyperlinkedit
        if (e.Column == gcLink)
        {
            var person = gridView1.GetRow(e.RowHandle) as Person;
            if (person != null)
            {
                // Logic to show/hide the link based on other field
                if (person.FirstName == "John")
                    e.DisplayText = string.Empty;
                else
                    e.DisplayText = person.Link;
            }
        }
    }
