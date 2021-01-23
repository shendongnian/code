    public class MagicString()
    {
    DateTime creationDate;
    private string _text;
    
    public MagicString(string text)
    {
    this.text = _text;
    creationDate = dateTime.
    }
    
    public override string ToString()
    {
     if (creationDate.AddMinutes(1) > DateTime.Now)
    {
    return HARDCODEDSTRING;
    }
    else 
    {
    return _text;
    }
    
    }
}
