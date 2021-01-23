    Bitmap img = eventArgs.Frame;
    for (int i = 0; i < 1000; i++)
    {
        // JPEGStream JPEGSource = new JPEGStream(streamingSource);
        // save it to folder like d:\images\
        // if you are saving images to folder using any other program 
        // then this might not be needed
        string[] filePaths = Directory.GetFiles(@"d:\images\");
        foreach(string f in filePaths)
        {
            img = Image.FromFile(f);
            writer.AddFrame(img);
        }
    }
    writer.Close();
