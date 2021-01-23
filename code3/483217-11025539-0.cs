            string selectText = string.Empty;
            Word.Selection wordSelection = this.Application.Selection;
            if (wordSelection != null && wordSelection.Range != null)
            {
                selectText = wordSelection.Text;
            }
