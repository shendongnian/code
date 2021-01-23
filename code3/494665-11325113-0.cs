    private void form_Load(object sender, EventArgs e){
     Bitmap bm = new Bitmap(sizeX,sizyY);
     pictureBox.Image = bt;
    }
    
    private void button1_Click(object sender, EventArgs e){
     Graphics g = Graphics.FromImage(pictureBox.Image);
     //Draw graphics...
     pictureBox.Image.Save(filename);
    }
