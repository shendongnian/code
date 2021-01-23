    private int _myInteger = 0;
    private int MyInteger {
        get
        {
             return _myInteger;
        } 
        set 
        {
            _myInteger = value;
            if (_myInteger <= MAX_INPUT)
                MyCallBackFunction();
        }
    }
    private void Right_Button_Click(object sender, RoutedEventArgs e)
    {
        MyInteger = MyInteger + 1;
        // Do your other stuff here
    }
    private void MyCallBackFunction()
    {
        // This function executes when your integer is <= MAX_VALUE
        // Do Whatever here
        display_result();
    }
