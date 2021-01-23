    public ObservableCollection<MyObject> MyList { get; set; }
    
    // blah blah blah
    
    public void InitializeMyList()
    {
      MyList = new ObservableCollection<MyObject>();
      for (int i = 0; i < 5; i++)
      {
        MyList.Add(InitializeMyObject(i));
      }
    }
    
    public MyObject InitializeMyObject(int i)
    {
      MyObject theObject = new MyObject();
      theObject.MyID = i;
      theObject.MyString = "The object " + i;
      theObject.MyCommand = new RelayCommand(param =< this.ShowWindow(i));
      return theObject
    }
    
    private void ShowWindow(int i)
    {
      // Just as an exammple, here I just show a MessageBox
      MessageBox.Show("You clicked on object " + i + "!!!");
    }
