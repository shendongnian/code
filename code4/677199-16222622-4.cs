    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using AForge;
    
    namespace stack_question
    {
    	public partial class Class2 : System.Web.UI.Page
    	{
    		Class1 myClass1 = new Class1();
    		
    		protected void Page_Load(object sender, EventArgs e)
    		{
    			setTextLabel();
    		}
    	  
    		private void setTextLabel()
    		{
    
    			label1.Text += "Center: " + myClass1.center.ToString() + "<br/>";
    			label1.Text += "Radius: " + myClass1.radius.ToString() + "<br/>";
    			foreach (IntPoint ip in myClass1.corners)
    			{
    				label1.Text += "IntPoint: " + ip.X.ToString();
    				label1.Text += ", ";
    				label1.Text += ip.Y.ToString() + "<br/>";
    			}
    		}
    	}
    }
