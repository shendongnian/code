    namespace SpinningLogo
    {
        class test
        {
            public void square(PictureBox thePB)
            {
                Bitmap bm = new Bitmap(square.Width, square.Height);
                Graphics baseImage = Graphics.FromImage(bm);
                baseImage.DrawRectangle(Pens.Black, 0, 0, 100, 100);
                thePB.Image = bm;
            }
    
        }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        test square = new test(myPictureBox);  //whatever it's really named
        square.square();
    }
