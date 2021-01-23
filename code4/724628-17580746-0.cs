    private void DeleteCard(Image img)
    {
        playersCards.Add(Properties.Resources.Card_1);
        if (img == playersCards[0])
        {
            playersCards.Remove(Properties.Resources.Card_1);
            MessageBox.Show(playersCards.Count.ToString());
        }
        else
        {
            MessageBox.Show("NO");
        }
    }
    private void frmQuickSpark_Load(object sender, EventArgs e)
    {
        Button tstbtn = new Button();
        tstbtn.BackgroundImage = Properties.Resources.Card_1;
        Image img = tstbtn.BackgroundImage;
        DeleteCard(img);
    }
