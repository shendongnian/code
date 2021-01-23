    [STAThread]
    static void Main() {
        CheckForUpdate();
        SetAddRemoveProgramsIcon();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault( false );
        Application.Run( new MainForm(WasUpdated) );
    }
    //WasUpdated is a class level variable that gets set inside of the CheckForUpdate method
