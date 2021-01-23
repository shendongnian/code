    void StartButton_Click(object sender, EventArgs e)
    {
        GameWorld gw = new GameWorld();
        // Initialize gw instance here
        GameForm mainForm = new GameForm(gw);
        mainForm.Show();
    }
