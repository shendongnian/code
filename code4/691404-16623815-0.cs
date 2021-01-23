    Random r = new Random();
    Color[] colarr = new Color[6];
    for (int i = 0; i < colarr.Length; i++)
    {
       Color c=new Color();
       c.R = (byte)r.Next(0, 256);
       c.G = (byte)r.Next(0, 256);
       c.B = (byte)r.Next(0, 256);
       c.A = (byte)r.Next(0, 256);
       //c.B = (byte)r.Next(1, 255);  This line isn't needed btw        
       colarr[i] = c;
    }
