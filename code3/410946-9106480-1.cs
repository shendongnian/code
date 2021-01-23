    _class2 = new Class2();
    _class2.AddButton("button1",ButtonClick);
    _class2.AddButton("button2",ButtonClick);
    _class2.AddButton("button3",ButtonClick);
    //in class2
    public void AddButton(string buttonName, EventHandler handler)
    {
       var newButton = new Button(buttonName);
       newButton.click+= handler;
    }
