	public static bool IsKeyAChar(Keys key)
	{
		return key >= Keys.A && key <= Keys.Z;
	}
	public static bool IsKeyADigit(Keys key)
	{
		return (key >= Keys.D0 && key <= Keys.D9) || (key >= Keys.NumPad0 && key <= Keys.NumPad9);
	}
