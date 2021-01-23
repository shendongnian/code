    public List<ComputerRecord> GridInventory
    {
        get { return _gridInventory; }
        set 
        { _gridInventory = value; 
          RaisePropertyChanged("GridInventory");
        }
    }
