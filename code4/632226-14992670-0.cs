    Loginf fLogin = new Loginf();
    DialogResult result = fLogin.ShowDialog();
    if (result == DialogResult.OK)
    {
        Application.Run(new Home2());
    }
    else if (result == DialogResult.No)
    {
        Application.Run(new Home3());
    }
    else
    {
        Application.Exit();
    }
