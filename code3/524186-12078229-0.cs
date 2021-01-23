    public void Registar(object sender, EventArgs e)
    {
        string Username = Utilizador.Text; 
        string PassWd = Password.Text;
        RegisterUser(Username, PassWd, 1);
    }
