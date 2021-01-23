    public void Copy()
    {
        var selection = (Range)Application.Selection;
        selection.Copy();
    }
    
    public void Paste()
    {
        var selection = (Range)Application.Selection;
        selection.PasteSpecial();
    }
