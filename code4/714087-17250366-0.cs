    private void addGameToolStripMenuItem_Click(object sender, EventArgs e)
    {
      NewGame newGame = new NewGame();
      newGame.ShowDialog(this);
      if (newGame.DialogResult==DialogResult.OK)
      {
        string gameName = newGame.GetGameName(); //this part doesn't work
      }
    }
     
