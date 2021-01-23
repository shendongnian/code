			using (var lower = new Bitmap(@"lower.png"))
			using (var upper = new Bitmap(@"upper.png"))
			using (var output = new Bitmap(lower.Width, lower.Height))
			{
				var width = lower.Width;
				var height = lower.Height;
				
				for (var i = 0; i < height; i++)
				{
					for (var j = 0; j < width; j++)
					{
						var upperPixel = upper.GetPixel(j, i);
						var lowerPixel = lower.GetPixel(j, i);
						var lowerColor = new HSLColor(lowerPixel.R, lowerPixel.G, lowerPixel.B);
						var upperColor = new HSLColor(upperPixel.R, upperPixel.G, upperPixel.B) {Luminosity = lowerColor.Luminosity};
						var outputColor = (Color)upperColor;
						output.SetPixel(j, i, outputColor);
					}
				}
				// Drawing the output image
			}
