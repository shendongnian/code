    public float Weight
    {
        get { return _weight; }
        set { SetProperty(ref value, 
                          ref _weight, 
                          true, 
                          this.Weight.ToString(), //just use ToString method
                          this.Age.ToString());   //just use ToString method
            }
    }
