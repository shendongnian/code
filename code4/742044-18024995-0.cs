    myControl.Click += new EventHandler(myGenericClickMethod);
    
    public void myGenericClickMethod(Object sender, EventArgs e)
    {
      Image myImage = (Image) sender;
      myImage..Visibility = System.Windows.Visibility.Collapsed;
    }
