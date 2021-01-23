    public class RadioButtonListAdapter : WebControlAdapter
    {
    	protected override void RenderBeginTag(HtmlTextWriter writer)
    	{
    		writer.RenderBeginTag("div");
    	}
    
    	protected override void RenderEndTag(HtmlTextWriter writer)
    	{
    		writer.RenderEndTag();
    	}
    
    	protected override void RenderContents(HtmlTextWriter writer)
    	{
    		var adaptedControl = (RadioButtonList) Control;
    		int itemCounter = 0;
    			
    		writer.Indent++;
    		foreach (ListItem item in adaptedControl.Items)
    		{
    			var inputId = adaptedControl.ClientID + "_" + itemCounter++;
    
    			// item div
    			writer.RenderBeginTag("div");
    			writer.Indent++;
    
    				// input
    				writer.AddAttribute("type", "radio");
    				writer.AddAttribute("value", item.Value);
    				writer.AddAttribute("name", adaptedControl.ClientID);
    				writer.AddAttribute("id", inputId);
    
    				writer.RenderBeginTag("input");
    				writer.RenderEndTag();
    
    				// label
    				writer.AddAttribute("for", inputId);
    				
    				writer.RenderBeginTag("label");
    				
    				writer.Write(item.Value);
    					
    				writer.RenderEndTag();
    
    			// div
    			writer.Indent--;
    			writer.RenderEndTag();
    		}
    		writer.Indent--;
    	}
    }
