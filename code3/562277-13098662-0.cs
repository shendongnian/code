    private void playerLabel_Click(object sender, EventArgs e)
    {
        string labelText = playerLabel.Text;
        if (Class.Method.Variable == 1)
        {
            labelText = "Player";
            Show.playerDetail();
        }
        else if(Class.Method.Variable == 0)
        {
            labelText = "Console";
            Show.consoleDetail();
        }
         
        playerLabel.Text = labelText;
    }
