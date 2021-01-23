    public bool IsChecked
    {
      get { return isChecked_; }
      
      set 
      { 
        isChecked_ = value;
        NotifyPropertyChanged_("IsChecked");
        if (value)
          MyContent = new MyType1();
        else
          MyContent = new MyType2();
      }
    }
