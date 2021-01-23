    // load images when you create a form
    private Bitmap image1 = InnovationX.Properties.Resources._1;
    private Bitmap image2 = InnovationX.Properties.Resources._2;
    private Bitmap image3 = InnovationX.Properties.Resources._3;
    // assing and compare loaded images
    private void timerImage_Tick(object sender, EventArgs e)
    {
        if (pictureBox1.Image == image1)
        {
            pictureBox1.Image = image2;
        }
        else if (pictureBox1.Image == image2)
        {
            pictureBox1.Image = image3;
        }
        else
        {
            pictureBox1.Image = image1;
        }
    }
