    namespace SpinningLogo
    {
        class test
        {
            public void square(PictureBox thePB)
            {
                Bitmap bm = new Bitmap(thePB.Width, thePB.Height);
                Graphics baseImage = Graphics.FromImage(bm);
                baseImage.DrawRectangle(Pens.Black, 0, 0, 100, 100);
                thePB.Image = bm;
            }
    
        }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        test square = new test();  //whatever it's really named
        square.square(myPictureBox);
    }
