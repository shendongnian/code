    public void CoinInserted(object sender, EventArgs e)
    {
        int tester = 0;
        if (Machine.TotalInsertedCoins == 0.05) { tester = 1; }
        if (Machine.TotalInsertedCoins > 0.05) { tester = 2; }
        switch (tester)
        {
            case 1:
                TextBox1.Text = "Inserted Coins: €" + Machine.TotalInsertedCoins;
                break;
            case 2:
                TextBox1.Text = "Inserted Coins: €" + Machine.TotalInsertedCoins + "0";
                break;
            default:
                TextBox1.Text = "Buy Your Ice Cold Drinks Here!";
                break;
        }
    }
