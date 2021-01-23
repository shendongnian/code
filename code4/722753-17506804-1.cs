    void DrawTextOnImage(Graphics grPhoto, string strText, Font font, Brush b, int num, Size imageSize)
    {
        //here we get dividers of our number
        int[] dividers = Dividers(num);
        //for first dimension I've choosen the biggest number, but you can change it
        int CountX = dividers[dividers.Length-1];
        //the secod dimension
        int CountY = num / CountX;
        //size of one text 
        int imageW = (int)grPhoto.MeasureString(strText, font).Width;
        int imageH = (int)grPhoto.MeasureString(strText, font).Height;
        //string format
        StringFormat StrFormat = new StringFormat();
        StrFormat.Alignment = StringAlignment.Center;
        //now when we knownumber of rows and columns and their size, we can start drawing
        for (int x = 0; x < CountX; x++)
        {
            for (int y = 0; y < CountY; y++)
            {
                PointF point = new PointF(      //position you want to know
                    (imageSize.Width - CountX * imageW) / 2 + (x * imageW),
                    (imageSize.Height - CountY * imageH) / 2 + (y * imageH)
                    );
                grPhoto.DrawString(strText,     //string of text
                font,                           //font
                b,                              //Brush
                point,                          //positio
                StrFormat);
            }
        }
    }
    int[] Dividers(int i)//get all dividers of number i
    {
        List<int> dividers = new List<int>();
        while (i > 1)
        {
            int div = NextDivider(i);
            dividers.Add(div);
            i = i / div;
        }
        return dividers.ToArray();
    }
    int NextDivider(int i)
    {
        if (i < 2) return i; //actualy it could be only value 1
        int div = 2;
        while (i % div != 0)
        {
            div++;
        }
        return div;
    }
