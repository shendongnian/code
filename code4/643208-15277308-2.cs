    namespace FindControlTest
    {
        public partial class ChildControl : System.Web.UI.UserControl
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                var textBoxTest = FindControlInContentPlaceHolder("TextBoxTest", "FeaturedContent") as TextBox;
    
                Response.Write(textBoxTest.Text);
                Response.End();
            }
    
            private Control FindControlInContentPlaceHolder(string controlID, string contentPlaceHolderID)
            {
                if (null == this.Page ||
                    null == this.Page.Master)
                {
                    return null;
                }
    
                var contentPlaceHolder = this.Page.Master.FindControl(contentPlaceHolderID);
                var control = getChildControl(controlID, contentPlaceHolder);
                return control;
            }
    
            private Control getChildControl(string controlID, Control currentControl)
            {
                if (currentControl.HasControls())
                {
                    foreach(Control childControl in currentControl.Controls)
                    {
                        if (null != childControl.FindControl(controlID))
                        {
                            return childControl.FindControl(controlID);
                        }
                        else
                        {
                            return getChildControl(controlID, childControl);
                        }
                    }
                }
    
                return null;
            }
        }
    }
