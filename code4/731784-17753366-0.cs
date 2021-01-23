    private void SearchCriteria_KeyDown(object sender, System.Windows.Input.KeyEventArgs e
    {
        if (e.Key.ToString() == "Space")
        {
            DelLast = SearchCriteria.Text;
            NeedsToDelete = true;
            _selectionStart = SearchCriteria.SelectionStart;
        }
    }
    private void SearchCriteria_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (NeedsToDelete == true)
        {
            SearchCriteria.Text = DelLast;
            SearchCriteria.SelectionStart = _selectionStart;
            NeedsToDelete = false;
        }
    }
