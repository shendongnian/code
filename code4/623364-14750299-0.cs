    private string text1;
    public string Text1
    {
    get{return this.text1;}
    set{
    this.text1 = value;
    OnPropertyChanged("Text1");}
    }
    private string text2;
    public string Text2
    {
    get{return this.text2;}
    set{
    this.text2 = value;
    OnPropertyChanged("Text2");}
    }
