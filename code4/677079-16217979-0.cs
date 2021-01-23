    private int id;
    public int Id {
        get { return id; }
        set {
            if(id != value) {
                id = value;
                SendPropertyChanged(); // let C# 5 compiler tricks supply the name
            }
        }
    }
    private void SendPropertyChanged([CallerMemberName]string propertyName = null)
    {
        var handler = PropertyChanged;
        if(handler != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));  
        }
    }
