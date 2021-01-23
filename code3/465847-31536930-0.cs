     [DllImport("user32.dll", CharSet = CharSet.Auto)]
     extern static bool DestroyIcon(IntPtr handle);
     public static Icon ConvertoToIcon(Bitmap bmp)
     {
         System.IntPtr icH = bmp.GetHicon();
         var toReturn = (Icon)Icon.FromHandle(icH).Clone();
         DestroyIcon(icH);
         return toReturn;
     }
