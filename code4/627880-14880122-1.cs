    private int index;
    private async void button4_Click(object sender, EventArgs e) 
    { //      ↑
        index++;
        if (index >= images.Count) index = 0;
        var bitmap = (Bitmap)images[index];
    
        pictureBox1.Image = bitmap;
        pictureBox1.Image = await Task.Run(() =>
        { //                  ↑
            return Iprocessing.Colour_style1(bitmap);
        });
    }
