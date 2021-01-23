    int numClicks = 0;
    
    private void pictureBox1_Click(object sender, EventArgs e)
    {
        if (numClicks >= 5)
        {
            MessageBox.Show("Clicking once");
            numClicks = 0;
        }
        else
            numClicks++;
    }
