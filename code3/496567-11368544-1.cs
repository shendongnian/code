    DecendedTextBox myControl = new DecendedTextbox();
    Type typeToCheck = Type.GetType("TextBox");
    if (myControl.GetType().IsSubclassOf(typeToCheck))
    {
       Debug.WriteLine("Test");
    }
