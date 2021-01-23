    private void btnPushMe_Click(object sender, EventArgs e)
    {
        Die myRoll = new Die(1, 7);
        lblMain.Text = myRoll.Roll().ToString();
        
        Die myRoll2 = new Die(1, 13);
        lblMain2.Text = mySecondRoll.Roll().ToString();
    }
