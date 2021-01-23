    private void button1_Click(object sender, EventArgs e)
    {
        var places = new PictureBox[10]; // I used 10 as a test
        for (int i = 0; i < places.Length; i++)
        {
            // This does the work, it searches through the Control Collection to find
            // a PictureBox of the requested name. It is fragile in the fact the the
            // naming has to be exact.
            try
            {
                places[i] = (PictureBox)Controls.Find("pictureBox" + (i + 1).ToString(), true)[0];
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("pictureBox" + (i + 1).ToString() + " does not exist!");
            }
                 
        }
    }
