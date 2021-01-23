    private Image fadedEdge(Image input)
        {
            //img.Save("i.bmp");
            //Bitmap bmp = (Bitmap)img;
            Bitmap output = new Bitmap(input);
            int howfartofade = input.Width / 8;
            int i = 0;
            if (howfartofade > 255) i = howfartofade / 255;
            else i = (255 / howfartofade) + 1;
            if (i == 0) i = 1;
            int alp = 255;
            int counter = 0;
            for (int x = input.Width - howfartofade; x < input.Width; x++)
            {
                if (howfartofade > 255)
                {
                    counter++;
                    if (counter == i + 1)
                    {
                        alp -= 1;
                        counter = 0;
                    }
                }
                else
                {
                    alp -= (i);
                }
                for (int y = 0; y < input.Height; y++)
                {
                    if (alp >= 0)
                    {
                        Color clr = output.GetPixel(x, y);
                        clr = Color.FromArgb(alp, clr.R, clr.G, clr.B);
                        output.SetPixel(x, y, clr);
                    }
                    else
                    {
                        Color clr = output.GetPixel(x, y);
                        clr = Color.FromArgb(0, clr.R, clr.G, clr.B);
                        output.SetPixel(x, y, clr);
                    }
                }
            }
            
            return output;
        }
