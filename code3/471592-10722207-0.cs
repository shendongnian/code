    this.Controls[btnAdd.Name].MouseClick += new MouseEventHandler(MyControl_MouseClick);
    //...
    void MyControl_MouseClick(object sender, MouseEventArgs e)
    {
        var button = sender as Button;
 
        if (button.Name == "Add") // here is how to retrieve the button name
        {
            ...
        }
    }
