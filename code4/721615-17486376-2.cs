    public Model:INotifyPropertyChanged
     {
    private int id;
    private String name;
    public Model(_id, _name) 
      {
        id = _id;
        name = _name;
       }
    public int ID {
        get { return id; }
        set { id = value;  NotifyChanged("ID");}
        }
    public String Name
       {
        get { return name; }
        set { name = value;  NotifyChanged("Name");}
       }
    }
