      //(inside a static class)
      public static int GetSurface(this Rectangle rect){return rect.Width * rect.Height;}
      //calling
      Rectangle rect;
      var s = rect.GetSurface();
