    using Microsoft.Office.Interop.Word;
    	class WordProofing
    	{
    		private Application _wordApp;
    		private readonly Document _wordDoc;
    		private static object _oEndOfDoc = "\\endofdoc";
    		public WordProofing()
    		{
    
    			_wordApp = new Application { Visible = false };
    			_wordDoc = _wordApp.Documents.Add();
    		}
    		public void Close()
    		{
    			_wordDoc.Close(WdSaveOptions.wdDoNotSaveChanges);
    			_wordApp.Quit();
    		}
    
    		public string Proof(string proofText)
    		{
    			Range wRng = _wordDoc.Bookmarks.get_Item(ref _oEndOfDoc).Range;
    			wRng.Text = proofText;
    			ProofreadingErrors spellingErros = wRng.SpellingErrors;
    			foreach (Range spellingError in spellingErros)
    			{
    				SpellingSuggestions spellingSuggestions =
    					_wordApp.GetSpellingSuggestions(spellingError.Text,IgnoreUppercase:true);
    			
    				foreach (SpellingSuggestion spellingSuggestion in spellingSuggestions)
    				{
    					spellingError.Text = spellingSuggestion.Name;
    					break;
    				}
    			}
    			
    			string str = wRng.Text;
    			wRng.Text = "";
    			return str;
    		}
    	}
