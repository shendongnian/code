    using System.Drawing;
    using System.IO;
    
    namespace wbmp2png
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			foreach (string file in args)
    			{
    				if (!File.Exists(file))
    				{
    					continue;
    				}
    				byte[] data = File.ReadAllBytes(file);
    				int width = 0;
    				int height = 0;
    				int i = 2;
    				for (; data[i] >> 7 == 1; i++)
    				{
    					width = (width << 7) | (data[i] & 0x7F);
    				}
    				width = (width << 7) | (data[i++] & 0x7F);
    				for (; data[i] >> 7 == 1; i++)
    				{
    					height = (height << 7) | (data[i] & 0x7F);
    				}
    				height = (height << 7) | (data[i++] & 0x7F);
    				int firstPixel = i;
    				Bitmap png = new Bitmap(width, height);
    				for (int y = 0; y < height; y++)
    				{
    					for (int x = 0; x < width; x++)
    					{
    						png.SetPixel(x, y, (((data[firstPixel + (x / 8) + (y * ((width - 1) / 8 + 1))] >> (7 - (x % 8))) & 1) == 1) ? Color.White : Color.Black);
    					}
    				}
    				png.Save(Path.ChangeExtension(file, "png"));
    			}
    		}
    	}
    }
