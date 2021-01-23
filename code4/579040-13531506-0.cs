    private void PropertyChanged(string prop)
    {
       if( PropertyChanged != null )
       {
          PropertyChanged(this, new PropertyChangedEventArgs(prop);
       }
    }
