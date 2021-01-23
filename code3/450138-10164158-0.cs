    public static void MainMenu()
    {
        frmMain.MainForm.ScreenTextClear();
        frmMain.MainForm.ButtonEnable(true, false, false, false, false, false);
        frmMain.MainForm.ScreenText(true, "Welcome to the alpha of this game.");
        frmMain.MainForm.ScreenText(true, "Hi");
        frmMain.MainForm.ButtonText("New Game", "Load Game", "About", "---", "---", "---");  
        // Potential solution.
        frmMain.MainForm.btn1.Click += delegate(object sender, EventArgs e)
            {
                NewGame();
            };    
    }
