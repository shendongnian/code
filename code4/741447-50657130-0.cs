    ...
    // Create image from file and display it in the PictureBox
    Image image = GetCopyImage(imagePath);
    picSelectedPicture.Image = image;
    ...  
    
    private Image GetCopyImage(string path) {
        using (Image image = Image.FromFile(path)) {
            Bitmap bitmap = new Bitmap(image);
            return bitmap;
        }
    }  
