        Button dynamicbutton = new Button();
        dynamicbutton.Command += new CommandEventHandler(dynamicbutton_Command);
        dynamicbutton.CommandName = "myCommandName";
        dynamicbutton.CommandArgument = anyID;
    void dynamicbutton_Command(object sender, CommandEventArgs e)
    {
       // do stuff
    }
