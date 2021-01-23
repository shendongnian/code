    using System.Drawing;
    
    Bitmap img = new Bitmap("*imagePath*");
    for (int i = 0; i < img.GetWidth; i++)
    {
        for (int i = 0; i < img.GetWidth; i++)
        {
            Color pixel = img.GetPixel(i,j);
    
            if (pixel == *somecondition*)
            {
                **Store pixel here in a array or list or whatever** 
            }
        }
    } 
  
