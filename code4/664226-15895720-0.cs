    public void SaveNote(string path)
    {
        if(_rtbContent.InvokeRequired)
        {
            _rtbContent.Invoke(new MethodInvoker(delegate{_rtbContent.SaveFile(path, RichTextBoxStreamType.RichText}));
            //Below is also same as above
            //_rtbContent.Invoke(new MethodInvoker(()=>_rtbContent.SaveFile(path, RichTextBoxStreamType.RichText)));
        }
        else 
        {
            _rtbContent.SaveFile(path, RichTextBoxStreamType.RichText);    
        }
    }
