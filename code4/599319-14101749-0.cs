    private void UserInput_KeyPress(object sender, KeyPressEventArgs e)
    {
        PictureBox myPicBox = new PictureBox();
        myPicBox.Location = new Point(7, 240);
        myPicBox.Size = new System.Drawing.Size(140, 140);
        myPicBox.SizeMode = PictureBoxSizeMode.AutoSize;
        myPicBox.Margin = new Padding(3, 3, 3, 3);
        myPicBox.Visible = true;
    }
    private void PictureBoxSizeMode()
    {
    }
