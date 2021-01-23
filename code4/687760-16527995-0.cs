    public string ReadWordDoc(string Path)
    {
        // microsot word app object
        Microsoft.Office.Interop.Word.Application _objWord=null;
    
        // microsoft word document object
        Microsoft.Office.Interop.Word.Document _objDoc= null;
        
        // obj missing value (ms office)
        object _objMissing = System.Reflection.Missing.Value;
    
        // string builder object to hold doc's content
        StringBuilder _sb = new StringBuilder();
    
        try
        {
            // create new word app object
            _objWord= new Microsoft.Office.Interop.Word.Application();
    
            // check if the file exists
            if (!File.Exists(Path)) throw (new FileNotFoundException());
            
            // full path to the document
            object _objDocPath = Path;
            
            // readonly flag
            bool _objReadOnly = true;
    
            // open word doc
            _objDoc = _objWord.Documents.Open(
                ref _objDocPath,
                ref _objMissing,
                _objReadOnly,
                ref _objMissing,
                ref _objMissing,
                ref _objMissing,
                ref _objMissing,
                ref _objMissing,
                ref _objMissing,
                ref _objMissing,
                ref _objMissing,
                ref _objMissing,
                ref _objMissing,
                ref _objMissing,
                ref _objMissing,
                ref _objMissing);
    
            // read entire content into StringBuilder obj
            for (int i = 1; i <= _objDoc.Paragraphs.Count; i++)
            {
                _sb.Append(_objDoc.Paragraphs[i].Range.Text.ToString());
               _sb.Append("\r\n");
            }
    
            // return entire doc's content
            return _sb.ToString();
        }
        catch { throw; }
        finally 
        {
            _sb = null;
    
            if (_objDoc != null) { _objDoc.Close(); }
            _objDoc = null;
    
            if (_objWord != null) { _objWord.Quit(); }
            _objWord = null;
        }
    }
