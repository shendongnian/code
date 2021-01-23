    private void DrawPercentages(int[] percentages, Color[] colors, float[] volumetransfer){
       Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
       using(Graphics G = Graphics.FromImage(bmp)){
           //...
       }
    
       pictureBox1.Image = bmp;
    }
