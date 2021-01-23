    List<string> copies = new List<string>();
    public void Copy()
    {
        Microsoft.Office.Interop.Word.Selection wordSelection = Application.Selection;
        if (wordSelection != null && wordSelection.Range != null)
        {
            copies.Add(wordSelection.get_XML());
        }            
    }
    
    public void Paste(int index)
    {
        Microsoft.Office.Interop.Word.Selection wordSelection = Application.Selection;
        if (wordSelection != null && copies.Count > index)
        {
            wordSelection.InsertXML(copies[index]);
        }              
    }
