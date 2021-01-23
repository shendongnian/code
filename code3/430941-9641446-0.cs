    private int _filterLength = 0;
    private List<Object> _originalItems;
    
    private void txtFilter_TextChanged(object sender, EventArgs e)
    {
        if (txtFilter.Text.Length < _filterLength)
        {
            // reset DataSource if filter has had chars deleted
            // so we can re-filter on the original mainly for deletions)
            lbAvailable.DataSource = _originalItems;
        }
    
        _filterLength = txtFilter.Text.Length;
    
        // only filter if... there is a filter
        if (_filterLength > 0)
        {
            ApplyFilterToAvailable();
        }
    }
    
    private void ApplyFilterToAvailable()
    {
        var myOtherList = lbAvailable.Items.Cast<Object>().ToList();
        lbAvailable.DataSource = null;
    
        var filtered = myOtherList.Where(x => x.ToString().Contains(txtFilter.Text)).ToList();
    
        lbAvailable.DataSource = filtered;
    }
