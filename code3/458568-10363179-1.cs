    public class DrawingCanvas : Panel
    {
	public List<Visual> visuals = new List<Visual>();
	public void AddVisual(Visual visual)
	{
		if (visual == null)
			return;
		this.visuals.Add(visual);
		base.AddVisualChild(visual);
		base.AddLogicalChild(visual);
	}
	public void RemoveVisual(Visual visual)
	{
		if (visual == null)
			return;
		this.visuals.Remove(visual);
		base.RemoveVisualChild(visual);
		base.RemoveLogicalChild(visual);
	}
    }
