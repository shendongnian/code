    public class MyDivControl : System.Web.UI.Control
    {
    	private System.Data.DataTable tblMyResults;
    	protected override void Render(System.Web.UI.HtmlTextWriter writer)
    	{
    		// Get your Data (or do it on Page_Load if you'll need it more than once
    		if (tblMyResults != null && tblMyResults.Rows.Count > 0)
    		{
    			int iIndex = 0;
    			foreach (System.Data.DataRow rItem in tblMyResults.Rows)
    			{
    				writer.WriteLine("<div id=\"{0}_{1}\">", this.ClientID, iIndex++);
    				//Whatever content you want here using your rows.
    				writer.WriteLine("</div>");
    			}
    		}
    	}
    }
