    using System;
    using System.Drawing;
    
    namespace MeasureSize
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var size = GetTextSize("This is a test!", "Arial", 10, "normal", "bold");
    
    			Console.Write("Width: {0} / Heigth: {1}", size);
    			Console.ReadKey();
    		}
    
    		public static object[] GetTextSize(object value, object fontFamily, object size, object style, object weight)
    		{
    			if (value == null || fontFamily == null || size == null) { return new object[0]; }
    
    			var result = new object[2];
    			var text = value.ToString();
    			var font = default(Font);
    			var composedStyle = string.Concat(style ?? "normal", "+", weight ?? "normal").ToLowerInvariant();
    			var fontStyle = default(FontStyle);
    
    			switch (composedStyle)
    			{
    				case "normal+normal": fontStyle = FontStyle.Regular | FontStyle.Regular; break;
    				case "normal+bold": fontStyle = FontStyle.Regular | FontStyle.Bold; break;
    				case "italic+normal": fontStyle = FontStyle.Italic | FontStyle.Regular; break;
    				case "italic+bold": fontStyle = FontStyle.Italic | FontStyle.Bold; break;
    			}
    
    			font = new Font(fontFamily.ToString(), Convert.ToSingle(size), fontStyle, GraphicsUnit.Pixel);
    
    			using (var image = new Bitmap(1, 1))
    			using (var graphics = Graphics.FromImage(image))
    			{
    				var sizeF = graphics.MeasureString(text, font);
    
    				result[0] = Math.Round((decimal)sizeF.Width, 0, MidpointRounding.ToEven);
    				result[1] = Math.Round((decimal)sizeF.Height, 0, MidpointRounding.ToEven);
    			}
    
    			return result;
    		}
    	}
    }
