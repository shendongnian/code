    static void SomeMethodSomewhere()
    {
        ShowMessage("Boo");
    }
    ...
    static void ShowMessage(string message,
        [CallerLineNumber] int lineNumber = 0,
        [CallerMemberName] string caller = null)
    {
         MessageBox.Show(message + " at line " + lineNumber + " (" + caller + ")");
    }
