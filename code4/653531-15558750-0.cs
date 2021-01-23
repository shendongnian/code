    class DefaultValueTextBox : TextBox
    {
    	private bool _set;
    	private Font _baseFont;
    	private Color _baseColor;
    
    	public string PlaceholderText { get; set; }
    	public Color PlaceholderColor { get; set; }
    	public Font PlaceholderFont { get; set; }
    
    	public DefaultValueTextBox()
    	{
    		this._baseFont = this.Font;
    		this._baseColor = this.ForeColor;
    	}
    
    	protected override void OnGotFocus(EventArgs e)
    	{
    		if (!_set)
    		{
    			this.Text = String.Empty;
    			this.Font = this._baseFont;
    			this.ForeColor = this._baseColor;
    			this._set = true;
    		}
    
    		base.OnGotFocus(e);
    	}
    
    	protected override void OnLostFocus(EventArgs e)
    	{
    		if (Text.Length == 0)
    		{
    			this.Text = this.PlaceholderText;
    			this.ForeColor = this.PlaceholderColor;
    			this.Font = this.PlaceholderFont;
    			this._set = false;
    		}
    
    		base.OnLostFocus(e);
    	}
    }
