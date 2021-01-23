    private void button1_Click(object sender, EventArgs e)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Images|*.bmp;*.jpg;*.gif|All files|*.*";
    
                if (open.ShowDialog(this) == DialogResult.OK)
                {
    
                    var image = Image.FromFile(open.FileName);
                    var newImage = ScaleImage(image, 300, 400);
                    string path = "1.png";
                    newImage.Save(open.FileName, ImageFormat.Png);
                } 
