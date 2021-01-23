    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    //ASPX page
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         // Accessing on Page Load with AutoPostBack Property to True for DropDownLists.
        //Every time you select any value from DropDownList the Page will Post back and Selected 
       // value will be in Response.
            string selectedtime = this.TimerUserControl.SelectedTime;
         Response.Write("Time----->" + selectedtime);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //accessing the selected time property if the SelectedTime(Public) property is in User control 
            // Here you wont require to set the AutoPostBack Property  to true for DropDownLists.
            
            string selectedtime = this.TimerUserControl.SelectedTime;
            
            Response.Write("Time----->" + selectedtime);
        }
    
    
    
    }
