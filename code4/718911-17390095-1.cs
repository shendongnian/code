    public class User : BaseNotify
    {
    
    private userName;
    public string UserName 
    { 
    
    get {return userName;}
    set
    {
    userName = value;
    OnPropertyChanged("UserName");
    }
    
    }
