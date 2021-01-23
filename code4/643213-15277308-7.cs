    using System;
    using System.Web.UI.WebControls;
    
    namespace FindControlTest
    {
        public partial class ChildControl : System.Web.UI.UserControl
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                var placeHolderControl = this.Parent.FindControl("PlaceHolderTest") as PlaceHolder;
                var textBoxControl = placeHolderControl.FindControl("TextBoxTest") as TextBox;
                var textBoxText = textBoxControl.Text;
    
                Response.Write(textBoxText);
                Response.End();
            }
        }
    }
