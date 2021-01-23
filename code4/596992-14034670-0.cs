    public void CreateImageWithText(string text)
    {
    	using (var b = new Bitmap(200, 200))
    	{
    		using (var g = new Graphics.FromImage(b))
    		{
    			using (var f = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point))
    			{
    				var strFormat = new StringFormat();
    				strFormat.Alignment = StringAlignment.Center;
    				strFormat.LineAlignment = StringAlignment.Center;
    				
    				g.DrawString(text, f, Brushes.Blue, new Rectangle(0,0,200,200), strFormat);
    			}
    		}
            b.Save("C:\\image.jpg", ImageFormat.Jpeg);
    	}
    }
