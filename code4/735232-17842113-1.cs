        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
    
    namespace WebApplication1
    {
    	public partial class WebForm1 : System.Web.UI.Page
    	{
    		protected void Page_Load(object sender, EventArgs e)
    		{
    			LoadControls();
    		}
    
    		protected void Button1_Click(object sender, EventArgs e)
    		{
    			var radioButtonList = PlaceHolder1.FindControl("1") as RadioButtonList;
    			Label1.Text = radioButtonList.SelectedValue;
    		}
    
    		private void LoadControls()
    		{
    			var tmpRBL = new RadioButtonList();
    			tmpRBL.ID = "1";
    
    			for (int i = 1; i <= 5; i++)
    			{
    				var tmpItem = new ListItem(i.ToString(), i.ToString());
    				tmpRBL.Items.Add(tmpItem);
    			}
    
    			PlaceHolder1.Controls.Add(tmpRBL);
    		}
    	}
    }
