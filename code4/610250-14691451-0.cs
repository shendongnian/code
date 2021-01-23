    List<Bitmap> images = new List<Bitmap>();  
    Bitmap finalImage = new Bitmap(640, 480);
    ...
    //For each layer, I transform the data into a Bitmap (doesn't matter what kind of
    //data, in this question) and add it to the images list
    for (int i = 0; i < nLayers; ++i)
    {
        Bitmap bitmap = new Bitmap(layerBitmapData[i]));
        images.Add(bitmap);
    }
        
    using (Graphics g = Graphics.FromImage(finalImage))
    {
        //set background color
        g.Clear(Color.Black);
        //go through each image and draw it on the final image (Notice the offset; since I want to overlay the images i won't have any offset between the images in the finalImage)
        int offset = 0;
        foreach (Bitmap image in images)
        {
            g.DrawImage(image, new Rectangle(offset, 0, image.Width, image.Height));
        }   
    }
    //Draw the final image in the pictureBox
    this.layersBox.Image = finalImage;
    //In my case I clear the List because i run this in a cycle and the number of layers is not fixed 
    images.Clear();
