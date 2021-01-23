     public static void IncreaseHueBy(ref Color color, float value, out float hue)
     {
         float h, s, v;
    
         RgbToHsv(color.R, color.G, color.B, out h, out s, out v);
         h += value;
    
         float r, g, b;
    
         HsvToRgb(h, s, v, out r, out g, out b);
    
    
         color.R = (byte)(r);
         color.G = (byte)(g);
         color.B = (byte)(b);
    
         hue = h;
     }
    
     static void  RgbToHsv(float r, float g, float b, out float h, out float s, out float v)
     {
         float min, max, delta;
         min = System.Math.Min(System.Math.Min(r, g), b);
         max = System.Math.Max(System.Math.Max(r, g), b);
         v = max;				// v
         delta = max - min;
         if (max != 0)
         {
             s = delta / max;		// s
    
             if (r == max)
                 h = (g - b) / delta;		// between yellow & magenta
             else if (g == max)
                 h = 2 + (b - r) / delta;	// between cyan & yellow
             else
                 h = 4 + (r - g) / delta;	// between magenta & cyan
             h *= 60;				// degrees
             if (h < 0)
                 h += 360;
         }
         else
         {
             // r = g = b = 0		// s = 0, v is undefined
             s = 0;
             h = -1;
         }
    
     }
     static void HsvToRgb(float h, float s, float v, out float r, out float g, out float b)
     {
         // Keeps h from going over 360
         h = h - ((int)(h / 360) * 360);
    
         int i;
         float f, p, q, t;
         if (s == 0)
         {
             // achromatic (grey)
             r = g = b = v;
             return;
         }
         h /= 60;			// sector 0 to 5
    
         i = (int)h;
         f = h - i;			// factorial part of h
         p = v * (1 - s);
         q = v * (1 - s * f);
         t = v * (1 - s * (1 - f));
         switch (i)
         {
             case 0:
                 r = v;
                 g = t;
                 b = p;
                 break;
             case 1:
                 r = q;
                 g = v;
                 b = p;
                 break;
             case 2:
                 r = p;
                 g = v;
                 b = t;
                 break;
             case 3:
                 r = p;
                 g = q;
                 b = v;
                 break;
             case 4:
                 r = t;
                 g = p;
                 b = v;
                 break;
             default:		// case 5:
                 r = v;
                 g = p;
                 b = q;
                 break;
         }
     }
