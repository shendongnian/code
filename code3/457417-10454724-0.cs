    private void HueFilter()
    {
      float y;
      Bitmap i = (Bitmap)imgViwer.Image;
    
      for (int a = 0; a < i.Height; a++)
      {
    	  for (int c = 0; c < i.Width; c++)
    	  {					  
    		  y = i.GetPixel(c, a).GetHue();
    		  if (y >= 210 && y <= 260)
    		  {
    			  i.SetPixel(c, a, Color.Black);
    		  }
    	  }
      }
    
      imgViwer.Image = i;
    }
