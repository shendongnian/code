    Button buttonNew = new Button();
    buttonNew.Name = "btnDelTR" + (tlpTDersRows - 1).ToString();
    buttonNew.Text = "-";
    buttonNew.Location = new Point(oldX, oldY);
    buttonNew.Size = btnTSatirEkle.Size;
    this.Controls.Add(buttonNew);
    buttonNew.Tag = tlpTDersRows - 1;
    buttonNew.Click += SatirSil;
    private void SatirSil(object sender, EventArgs e)
    {
       //codes
       var btn = (Button)sender;
       var row = (int)btn.Tag;
       
    }
