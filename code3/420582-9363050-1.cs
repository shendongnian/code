    public void AppendTextAsRtf(string _text, Font _font, 
      RtfColor _textColor, RtfColor _backColor) {
    
      // Move carret to the end of the text
      this.Select(this.TextLength, 0);
      
      InsertTextAsRtf(_text, _font, _textColor, _backColor);
    }
