    try
    {
        // Do your validation stuff here...
        // The form will only show if the validation didn't throw.
        Application.Run(new Form1());
    }
    catch (Exception)
    {
        TextFile file = new TextFile();
        string info = datei.ReadFile("user_log");
        MessageBox.Show(info);
    }
