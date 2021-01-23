        Button buttonNew = new Button();
        ...
        buttonNew.Tag = (tlpTDersRows - 1);
        buttonNew.Click = SatirSil;
        ....
        void SatirSil(object sender, EventArgs e)
        {
           int rowNumber = (int)(sender as Control).Tag;
           //rest of code
        }
