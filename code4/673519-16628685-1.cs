    public class CustomControlCollection : Control.ControlCollection
    {
    	public new CustomForm Owner { get; private set; }
    	public CustomControlCollection (VlufiForm pOwner) : base(pOwner)
    	{
    		Owner = pOwner;
    	}
    	public override void Add(Control c)
    	{
    		Add(c, false);
    	}
    	public void Add(Control c, bool isUsable)
    	{
    		if (isUsable)
    			Owner.RealControls.Add(c);
    		else
    			Owner.ControlContainer.Controls.Add(c);
    	}
    }
