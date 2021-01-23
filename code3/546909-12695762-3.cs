    private void button1_Click(object sender, EventArgs e)
    {
        int die1 = throwDice.Next(1, 7);
        int die2 = throwDice.Next(1, 7);
        int die3 = throwDice.Next(1, 7);
        var results = new DiceResults(die1, die2, die3);
        label1.Text = results.Dice1;
        label2.Text = results.Dice2;
        label3.Text = results.Dice3;
        label4.Text = results.GetDiceTotal();
        inzet = Convert.ToInt32(textBox1.Text);
        gamble = Convert.ToInt32(textBox2.Text);
        int prize = results.GetPrize(gamble, inzet);
        textBox3.Text = prize;
    }
