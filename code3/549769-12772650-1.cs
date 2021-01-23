    string filename = "file.avi";
    string storagepath = @"temp\";
    static int counter = 0;
    MediaDetClass memde;
    
    private void button1_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            // Create the subfolder
            System.IO.Directory.CreateDirectory("temp");
    
    	// Some properities
            counter = 0;
            memde = new MediaDetClass();
            Image img;
            memde.Filename = openFileDialog1.FileName;
            memde.CurrentStream = 0;
            int len = (int)memde.StreamLength;
            float percent = 0.002f;//how far do u want for a single step
    
            for (float i = 0.0f; i < len; i = i + (float)(percent * len))
            {
    
                counter++;
                string fbitname = storagepath + counter.ToString();
                memde.WriteBitmapBits(i, 850, 480, fbitname + ".bmp");
                //img = Image.FromFile(fbitname + ".bmp");
                //img.Save(fbitname + ".bmp", ImageFormat.Bmp);
                //img.Dispose();
                //System.IO.File.Delete(i + fbitname + ".bmp");
            }
    }
