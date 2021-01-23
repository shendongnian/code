    private void frmQuickSpark_Load(object sender, EventArgs e)
        {
            Button btn = new Button();
            SetButtonImage(btn);
            DeleteCard(btn);
        }
     private void SetButtonImage(Button button)
        {
            
            button.BackgroundImage = Properties.Resources.Card_1;
            button.BackgroundImage.Tag = Properties.Resources.Card_1.Name??; // Not sure, name or other marker
        }
        private void DeleteCard(Button btn)
    {
        if (btn.BackgroundImage.Tag == FunWaysInc.Properties.Resources.Card_1.Name) // Again, Name or other property - tag it!!
        {
            playersCards.Remove(Properties.Resources.Card_1);
            MessageBox.Show(playersCards.Count.ToString());
        }
        else
        {
            MessageBox.Show("NO");
        }
    }
