    if (blah.Text != string.Empty)
    {
        if (rowViewFilter == string.Empty)
        {
            rowViewFilter = string.Format("(name = '{0}')", blah.Text);
        }
        else
        {
            rowViewFilter += string.Format(" and (name = '{0}')", blah.Text);
        }
    }
