    delegate void SaveNoteCallback(string path);
    public void SaveNote(string path)
    {
        if(_rtbContent.InvokeRequired)
        {
            SaveNoteCallback d = new SaveNoteCallback(SaveNote);
            this.Invoke(d, new object[] {path});
        }
        else 
        {
            _rtbContent.SaveFile(path, RichTextBoxStreamType.RichText);    
        }
    }
