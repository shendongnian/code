    public class CustomControlCollection 
    {
    	public VlufiForm Owner { get; private set; }
    	public CustomControlCollection (VlufiForm pOwner)
    	{
    		Owner = pOwner;
    	}
    	public void Add(Control c)
    	{
    		Add(c, false);
    	}
    	public int Count
    	{
    		get
    		{
    			return Owner.ControlContainer.Controls.Count;
    		}
    	}
    	public Control this[int index]
    	{
    		get
    		{
    			return Owner.ControlContainer.Controls[index];
    		}
    	}
    	public void Add(Control c, bool isUsable)
    	{
    		if (isUsable)
    			Owner.RealControls.Add(c);
    		else
    			Owner.ControlContainer.Controls.Add(c);
    	}
    	public void SetChildIndex(Control c, int nIndex)
    	{
    		Owner.ControlContainer.Controls.SetChildIndex(c, nIndex);
    	}
    }
