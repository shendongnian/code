        private Bitmap bmp1;
        private void preview()
        {
            if (bmp1 != null)
            {
                bmp1.Dispose();
            }
            bmp1 = new Bitmap(2480, 3508);
            panel1.DrawToBitmap(bmp1, new Rectangle(0, 0, 2480, 3508));
            pictureBox2.Image = bmp1;
        }
