    public void InsertTextAsRtf(string _text, Font _font, 
        RtfColor _textColor, RtfColor _backColor) {
    
        StringBuilder _rtf = new StringBuilder();
    
        // Append the RTF header
        _rtf.Append(RTF_HEADER);
    
        // Create the font table from the font passed in and append it to the
        // RTF string
        _rtf.Append(GetFontTable(_font));
    
        // Create the color table from the colors passed in and append it to the
        // RTF string
        _rtf.Append(GetColorTable(_textColor, _backColor));
    
        // Create the document area from the text to be added as RTF and append
        // it to the RTF string.
        _rtf.Append(GetDocumentArea(_text, _font));
    
        this.SelectedRtf = _rtf.ToString();
      }
