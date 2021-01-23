    private PosList<Pos> _position = new PosList<Pos>(new List<Pos>());
    public PosList<Pos> Position
    {
        get { return _position; }
        set
        {
            _position = value;
            NotifyPropertyChanged("Position");
        }
    }
