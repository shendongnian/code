    public class HtmlTextWrapper {
    
    //private members
       private HtmlTextWriterStyle _htmlTextWriterStyle;
    
    
    //public props same as the wrapped htmltextwriterstyle
    	public string BackgroundColor { 
    		get
    		{
    			if (_htmlTextWriterStyle != null)
    			{
    				return _htmlTextWriterStyle.BackgroundColor;
    			}
    		}
    		set
    		{
    			if (_htmlTextWriterStyle != null)
    			{
    				this._htmlTextWriterStyle.BackgroundColor = value;
    			}
    		}
    	}
    
    	public string BackgroundImage {get;set; }
    	//....
    	//....
    
    
    //construcor
         public HtmlTextWrapper(HtmlTextWriterStyle other)
         {
    			_htmlTextWriterStyle = other;
         }
    
    
    
    }
