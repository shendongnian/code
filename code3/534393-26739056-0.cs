    using mshtml;
    private int _findClicks = 0;
    private string _searchText = "";
    public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (value.ToUpper() != _searchText)
                {
                    ClearFind();
                    _searchText = value.ToUpper();
                    txtSearch.Text = value.ToUpper();
                    _findClicks = 0;
                }
            }
        }
    private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchText = txtSearch.Text;
            if (_findClicks == 0)
                FindFirst();
            else
                FindNext();
        }
     /// <summary>
        /// Search through all text to find. Sets all occurrences to background color yellow.
        /// </summary>
        private void FindFirst()
        {
                if (_searchText == "")
                    return;
                IHTMLDocument2 doc = webBrowser1.Document.DomDocument as IHTMLDocument2;
                IHTMLSelectionObject sel = doc.selection;
                IHTMLTxtRange range = sel.createRange() as IHTMLTxtRange;
                //Mark all occurrences with background color yellow
                while (true)
                {
                    if ((range.findText(_searchText)) && (range.htmlText != "span style='background-color: yellow;'>" + _searchText + "</span>"))
                    {
                        range.pasteHTML("<span style='background-color: yellow;'>" + _searchText + "</span>");
                    }
                    else
                        break;
                }
                //Move to beginning and select first occurence.
                range.moveStart("word", -9999999);
                range.findText(_searchText);
                range.select();
                _findClicks++;
            }
    /// <summary>
        /// Finds next occurrence of searched text and selects it.
        /// </summary>
        private void FindNext()
        {
                if (_searchText == "")
                    return;
                IHTMLDocument2 doc = webBrowser1.Document.DomDocument as IHTMLDocument2;
                IHTMLSelectionObject sel = doc.selection;
                IHTMLTxtRange range = sel.createRange() as IHTMLTxtRange;
                range.collapse(false); // collapse the current selection so we start from the end of the previous range
                if (range.findText(_searchText, 1000000, 0))
                {
                    range.select();
                }
                else // If at end of list, go to beginning and search one more time.
                {
                    range.moveStart("word", -9999999);
                    if (range.findText(_searchText, 1000000, 0))
                    {
                        range.select();
                    }
                }
        }
    /// <summary>
        /// Remove highlighting on all words from previous search.
        /// </summary>
        private void ClearFind()
        {
                if (_searchText == "" || webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                    return;
                IHTMLDocument2 doc = webBrowser1.Document.DomDocument as IHTMLDocument2;
                IHTMLSelectionObject sel = doc.selection;
                IHTMLTxtRange range = sel.createRange() as IHTMLTxtRange;
                range.moveStart("word", -9999999);
                while (true)
                {
                    if ((range.findText(_searchText)) && (!range.htmlText.Contains("span style='background-color: white")))
                    {
                        range.pasteHTML("<span style='background-color: white;'>" + _searchText + "</span>");
                    }
                    else
                        break;
                }
           
        }
