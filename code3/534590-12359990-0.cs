    private static int CompareByArea(Rectangle r1, Rectangle r2)
    {
       int a1 = r1.Width * r1.Height;
       int a2 = r2.Width * r2.Height;
       if (a1 < a2)
       {
          return - 1;
       }
       else
       {
         if (a1 > a2) 
         {
            return 1; 
         }
       }
       return 0;
    }
