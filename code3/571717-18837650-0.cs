    private int lastUsedIndex = 0;
    		public void Find(string searchQuery)
    		{
    			if (string.IsNullOrEmpty(searchQuery))
    			{
    				lastUsedIndex = 0;
    				return;
    			}
    
    			string editorText = this.textEditor.Text;
    
    			if (string.IsNullOrEmpty(editorText))
    			{
    				lastUsedIndex = 0;
    				return;
    			}
    
    			if (lastUsedIndex >= searchQuery.Count())
    			{
    				lastUsedIndex = 0; 
    			}
    
    			int nIndex = editorText.IndexOf(searchQuery, lastUsedIndex);
    			if (nIndex != -1)
    			{
    				var area = this.textEditor.TextArea;
    				this.textEditor.Select(nIndex, searchQuery.Length);
    				lastUsedIndex=nIndex+searchQuery.Length;
    			}
    			else
    			{
    				lastUsedIndex=0;
    			}
    		}
