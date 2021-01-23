                public static class ControlExts
                {
                          public static Color GetPixelColor(this Control c, int x, int y)
                          {
                             this.BeginInvoke(new Action(() =>
                              {
                              var screenCoords = c.PointToScreen(new Point(x,y));
                              return Win32.GetPixelColor(screenCoords.X, screenCoords.Y);
                             }));
                           }
               }
                
                    
                
