    private void BoomUp_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            currentButton_ = e.Button;//but I don't know if e.Button has a Name "BoomUp"
            //you can set the name manually if needed :
            currentButton_.Name = "BoomUp";
    
            //ButtonTimer.Enabled = true;
            ButtonTimer.Start();
        }
    }
