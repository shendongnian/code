    using(var image = Image.FromFile(imagePath))
    {
       using(var newImage = ScaleImage(image, 300, 400))
       {
           newImage.Save(imagePathZmniejszony);
       }
    }
