    List<Image> imageList = new List<Image>();
    for (int i = 1; i <= totalCount; i++)    
    {
            Bitmap bmp = new Bitmap(800,2000))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawString(i.ToString(), new Font("Arial", 40), Brushes.Black, new PointF(400,1000));   
            }
            
            imageList.Add(bmp);
    }
