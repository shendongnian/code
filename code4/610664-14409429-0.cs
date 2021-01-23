    // Program.cs
    public static ProgramForm Form;
    publi static void Main()
    {
        // ...
        Application.Run(Form = new ProgramForm());
        // ...
    }
    public static void ChangeText(String message)
    {
        Form.TextBox1.Text = message;
    }
    // ProgramForm.cs
    private void Client_MessageReceived(object sender, MessageEventArgs e)
    {
        if (e.Message != null)
            Program.ChangeText(e.Message);
    }
