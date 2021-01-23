    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.IO;
    //using System.Globalization;
    namespace colorchange
    {
       class Program
       {
          static void Main(string[] args)
          {
              try
              {
                  ImageHandler ih = new ImageHandler();
                  Bitmap bmp = null;
                  //The Source Directory in debug\bin\Big\
                  string[] files = Directory.GetFiles("Big\\");
                  foreach (string filename in files)
                  {
                     bmp = (Bitmap)Image.FromFile(filename);                    
                     bmp = ChangeColor(bmp);
                     string[] spliter = filename.Split('\\');
                     //Destination Directory debug\bin\BigGreen\
                     bmp.Save("BigGreen\\" + spliter[1]);
                  }                                                 
               }
               catch (System.Exception ex)
               {
                  Console.WriteLine(ex.ToString());
               }            
           }        
           public static Bitmap ChangeColor(Bitmap scrBitmap)
           {
              //You can change your new color here. Red,Green,LawnGreen any..
              Color newColor = Color.Red;
              Color actulaColor;            
              //make an empty bitmap the same size as scrBitmap
              Bitmap newBitmap = new Bitmap(scrBitmap.Width, scrBitmap.Height);
              for (int i = 0; i < scrBitmap.Width; i++)
              {
                 for (int j = 0; j < scrBitmap.Height; j++)
                 {
                    //get the pixel from the scrBitmap image
                    actulaColor = scrBitmap.GetPixel(i, j);
                    // > 150 because.. Images edges can be of low pixel colr. if we set all pixel color to new then there will be no smoothness left.
                    if (actulaColor.A > 150)
                        newBitmap.SetPixel(i, j, newColor);
                    else
                        newBitmap.SetPixel(i, j, actulaColor);
                 }
              }            
              return newBitmap;
           }
       }
    }
