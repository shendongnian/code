    int i = 0;
    public void nextCardButton_Click(object sender, EventArgs e)
    {
        i++;
        label1.Text = player1[i].cardName;
        percentageLabel1.Text = player1[i].cardPercentage.ToString();
        qualityLabel2.Text = player1[i].cardQuality.ToString();
        quantityLabel2.Text = player1[i].cardQuantity.ToString();
        tasteLabel2.Text = player1[i].cardTaste.ToString();
    }
