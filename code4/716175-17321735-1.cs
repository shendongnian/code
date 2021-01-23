    //Loop through the 5 images
    for (int i = 0; i < 5; i++) {
        //Output the image with the current index (adding 1 since we're starting at zero)
        phrase.Add(new Chunk("C-IMG" + (i + 1).ToString() + " :\u00a0", normalFont));
        //It appears 8 is the "magic number" of the column so add whatever index we're currently on
        Byte[] bytes = (Byte[])dr[8 + i];
        if (bytes.Length == 0) {
            //Do something special with the empty ones
        } else {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(bytes);
            image.ScaleToFit(112f, 112f);
            Chunk imageChunk = new Chunk(image, 0, 0);
            phrase.Add(imageChunk);
        }
    }
