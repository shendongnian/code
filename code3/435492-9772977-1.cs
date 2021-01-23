    public void MyMethod(Action<string> displayError)
    {
        if (displayError == null) { throw new ArgumentNullException("I need this!"); }
        displayError("ERROR");
    }
