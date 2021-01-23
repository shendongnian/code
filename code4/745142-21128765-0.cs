	static List<SolidColorBrush> cacheSCBrushes = new List<SolidColorBrush>();
	public static SolidColorBrush GetColorBrush(Color4 Color, Direct2D.RenderTarget renderTGT)
	{
		 // ERROR: Not supported in C#: OnErrorStatement
		SolidColorBrush returnBrush = null;
		bool found = false;
		foreach (void br_loopVariable in cacheSCBrushes) {
			br = br_loopVariable;
			if (br.Color.Red == Color.Red) {
				if (br.Color.Green == Color.Green) {
					if (br.Color.Blue == Color.Blue) {
						if (br.Color.Alpha == Color.Alpha) {
							found = true;
							returnBrush = br;
							exit for;
						}
					}
				}
			}
		}
		if (!found) {
			returnBrush = new SolidColorBrush(renderTGT, Color);
			cacheSCBrushes.Add(returnBrush);
		}
		return returnBrush;
	}
	public static void ClearCache()
	{
		foreach (void Brush_loopVariable in cacheSCBrushes) {
			Brush = Brush_loopVariable;
			Brush.Dispose();
		}
	}
