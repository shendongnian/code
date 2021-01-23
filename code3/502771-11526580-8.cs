    private string _text;
    public string Text {
       get { return _text; }
       set {
           _text = value;
           
           // the text in the TextBox is about to change.
           if (!_text.Equals(value)) doSomething();
           FirePropertyChanged("Text");
       }
    }
