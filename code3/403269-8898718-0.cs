    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      DialogResult running = DialogResult.OK;
      while (running == DialogResult.OK) {
        form_login login = new form_login();
        Application.Run(login);
        running = login.DialogResult;
        if (login.DialogResult == DialogResult.OK)
          Application.Run(new Form1());
          // or your other forms...
      }
    }
