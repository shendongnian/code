    MyClass myClass = new MyClass();
    myClass.PropertyChanged += new PropertyChangedEventHandler(myClass_PropertyChanged);
    void myClass_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
         actual = e.PropertyName;     
    }
