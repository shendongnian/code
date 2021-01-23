    foreach (KeyValuePair<string, Book> b in books)
    {
        if (b.Value.Title.IndexOf(searchTerm,StringComparison.InvariantCultureIgnoreCase) >=0)
        {
            ISBNBox.Text = b.Value.ISBN.ToString();
            TitleBox.Text = b.Value.Title;
            chkLoan.Enabled = true;
        }
    }
