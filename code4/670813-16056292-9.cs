	// The Form or similar
	public class MyFormOrSimilar
	{	
		// When button pressed try and add strength to the player
		protected void AddButton_Click(object sender, EventArgs e)
		{
			// Create new INSTANCE of the player and try to give them strength
			Player thePlayer = new Player(int.Parse(StrBox.Text), int.Parse(SPBox.Text));
			if (thePlayer.GainStrength())
			{
				StrBox.Text = thePlayer.Strength.ToString();
				SPBox.Text = thePlayer.StatPoints.ToString();
			}
			else
			{
				MessageBox.Show("Earn more experience!");
			}
		}
	}
