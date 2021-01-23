    //*************************************//
    //** Thumbnail Selection Processing  **//
    //*************************************//
    /// <summary>
    /// Main Thumbnail selection area.  
    ///    If the Shift key is held down, look for a search between.  
    ///    If Ctrl key, do not clear selections as can select multiple.
    /// </summary>
    private void selectThumb(PictureBox _thumb)
    {
        if (Control.ModifierKeys == Keys.Shift)
            if (SelectMultipleThumbs(_thumb.getPageIndex()))  //** if another thumb is selected, select all in between, then exit  **//
                return;
        if (Control.ModifierKeys != Keys.Control)
        {
            ClearAllSelections();
        }
        else
        {
            if (_thumb.IsSelected == true)
            {
                _thumb.IsSelected = false;
                return;
            }
        }
        _thumb.IsSelected = true;
    }
    /// <summary>
    /// Check if there are other selected items.  If there is, select all between the start and end.
    /// </summary>
    private bool SelectMultipleThumbs(int _pageindex)
    {
        //** Check if there are other objects that have been selected **/
        int? otherSelPageIndex = GetPageIndexOfThumbSelected(_pageindex);
        if (otherSelPageIndex != null)
        {
            ApplySelectionBetweenStartEndPageIndex(_pageindex, Convert.ToInt32(otherSelPageIndex));
            return true;
        }
        return false;
    }
    /// <summary>
    /// Apply Selection if between start and end Pages
    /// </summary>
    private void ApplySelectionBetweenStartEndPageIndex(int _val1, int _val2)
    {
        int startThumb = _val1;
        int endThumb = _val2;
        if (_val1 > _val2)
        {
            startThumb = _val2;
            endThumb = _val1;
        }
        foreach (PictureBox thumbFrame in thumbFlow.Controls.OfType<PictureBox>().OrderBy(si => si.pageIndex))
        {
            if (isBetween(thumbFrame.getPageIndex(), startThumb, endThumb))
                thumbFrame.IsSelected = true;
            else
                thumbFrame.IsSelected = false;
        }
    }
    /// <summary>
    /// Clear All Highlight
    /// </summary>
    private void ClearAllSelections()
    {
        foreach (PictureBox thumbFrame in thumbFlow.Controls.OfType<PictureBox>())
        {
            thumbFrame.IsSelected = false;
        }
    }
    /// <summary>
    /// Check for any selected items prior
    /// </summary>
    private int? GetPageIndexOfThumbSelected(int _pageindex)
    {
        foreach (PictureBox thumbFrame in thumbFlow.Controls.OfType<PictureBox>())
        {
            if (thumbFrame.IsSelected &&
                _pageindex != thumbFrame.getPageIndex())
            {
                return thumbFrame.getPageIndex();
            }
        }
        return null;
    }
