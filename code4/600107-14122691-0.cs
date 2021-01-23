    using System.Text;
    using System.Web.UI;
    using System.ComponentModel;
    
    namespace ClientSide
    {
    	[DefaultProperty("Text"),
    	ToolboxData("<{0}:MessageBox runat=server>" 
    		+ "</{0}:MessageBox>")]
    	public class MessageBox : System.Web.UI.Control 
    	{
    		private string text="";
    		[Bindable(true),
    		Category("Appearance"),
    		DefaultValue("")]
    		public string Text
    		{
    			get	{return text;}
    			set	{text = value;}
    		}
    
    		protected override void Render(HtmlTextWriter output)
    		{
    			if (text.Length>0)
    			{
    				StringBuilder sb = new StringBuilder();
    				sb.Append("<script language='javascript'>");
    				sb.Append("alert('"+text+"')");
    				sb.Append("</script>");
    				output.Write(sb.ToString());
    			}
    		}
    	}
    }
