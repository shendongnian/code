    public int MaximumLength
    {
      get
      {
        return this.maximumLength;
      }
       
      set
      {
        if(value <= 4)
        {
          MessageBox.Show("Value is too small.");
        }
        else this.maximumLength = value;
      }
    }
