    public async  void button1_Click(object sender, EventArgs e)
    {
        pictureBox1.Image = await Task.Run(async() =>
        {
            using(Bitmap bmp1 = await DownloadFirstImageAsync())
            using(Bitmap bmp2 = await DownloadSecondImageAsync())
            return Mashup(bmp1, bmp2);
        });
    }
