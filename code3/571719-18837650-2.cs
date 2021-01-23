    public void Replace(string s, string replacement, bool selectedonly)
    		{
    			int nIndex = -1;
    			if(selectedonly)
    			{
    				nIndex = textEditor.Text.IndexOf(s, this.textEditor.SelectionStart, this.textEditor.SelectionLength);			
    			}
    			else
    			{
    				nIndex = textEditor.Text.IndexOf(s);
    			}
    
    			if (nIndex != -1)
    			{
    				this.textEditor.Document.Replace(nIndex, s.Length, replacement);
    		
		this.textEditor.Select(nIndex, replacement.Length);
			}
			else
			{
				lastSearchIndex = 0;
				MessageBox.Show(Locale.ReplaceEndReached);
			}
		}
