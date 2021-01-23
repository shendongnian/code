    public class DrawingCanvas : Panel
    {
	public List<Visual> Visuals = new List<Visual>();
	public void AddVisual(Visual Visual)
	{
		if (Visual == null)
			return;
		this.Visuals.Add(Visual);
		base.AddVisualChild(Visual);
		base.AddLogicalChild(Visual);
	}
	public void RemoveVisual(Visual Visual)
	{
		if (Visual == null)
			return;
		this.Visuals.Remove(Visual);
		base.RemoveVisualChild(Visual);
		base.RemoveLogicalChild(Visual);
	}
    }
