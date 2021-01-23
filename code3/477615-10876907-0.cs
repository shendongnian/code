    public double X {
        get { return TestPoint.X; }
        set { TestPoint.X = value;
              OnPropertyChanged("X");
            }
    }
