    public  void InitializeBMPObjects ()
     {
       Bitmap Bmp1 = new Bitmap(320, 226); 
       pushPixels(Bmp1);//bmp1 accessible only to pushPixels in this case
     }
     public void pushPixels(Bitmap bmp1)
     {
       Graphics g = Graphics.FromImage(Bmp1);
       //Do some graphics stuff....
     }
