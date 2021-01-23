    // The setup method
    void MyMethod()
    {
       //textBox.TextChanged += new Eventhandler(MyTextChangedHandler);  // C#1 and later
       textBox.TextChanged += MyTextChangedHandler;                      // C#2 and later
    }
    // The subscribed method. The lambda is an inline version of this. 
    private void MyTextChangedHandler(object s, EventArgs e)
    { 
       this.Foo(); 
    }
