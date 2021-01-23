    private void btnAccept_Click(object sender, EventArgs e)
    {
         for (int i = 0; i < 10; i++)
         {
              var player = new Player(((TextBox)this.Controls.FindControl("FHome" + i)).Text, ((TextBox)this.Controls.FindControl("LHome" + i)).Text, ((NumericUpDown)this.Controls.FindControl("upDownH" + i)).Value);
              HomeTeam.Add(player);
         }
    }  
