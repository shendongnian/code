    System.Drawing.Image original = System.Drawing.Image.FromFile(fullPath);
    int height = original.Height;
    int width = original.Width;
    int newHeight = height / 4;
    int newWidth = width / 4;
    System.Drawing.Bitmap newPic = new System.Drawing.Bitmap(newWidth , newHeight );
    System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(newPic);
    gr.DrawImage(original, 0, 0, (newWidth ), (newHeight ));
    string newFilename = ""; /* Put new file path here */
    newPic.Save(newFilename, System.Drawing.Imaging.ImageFormat.Jpeg);
    gr.Dispose();
    newPic.Dispose();
    original.Dispose();
