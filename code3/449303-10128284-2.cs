    using System.Drawing;
    
    Bitmap img = new Bitmap("*imagePath*");
    for (int i = 0; i < img.Width; i++)
    {
        for (int j = 0; j < img.Height; j++)
        {
            Color pixel = img.GetPixel(i,j);
    
            if (pixel == *somecondition*)
            {
                **Store pixel here in a array or list or whatever** 
            }
        }
    } 
  
