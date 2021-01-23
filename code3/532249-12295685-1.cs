	public ColorRange GetColorRange(int red, int green, int blue)
	{
		foreach (var colorRange in this.Ranges)
		{
			if (colorRange.RedRange.IsInRange(red)
				&& colorRange.GreenRange.IsInRange(green)
				&& colorRange.BlueRange.IsInRange(blue))
			{
				return colorRange;
			}
		}
		
		return null;
		
		/*
			Or with Linq:
			return this.Ranges.FirstOrDefault(colorRange => 
				colorRange.RedRange.IsInRange(red)
				&& colorRange.GreenRange.IsInRange(green)
				&& colorRange.BlueRange.IsInRange(blue));
		*/
	}
