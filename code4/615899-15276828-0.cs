    public partial class CustomSimpleFormAscx : SitecoreSimpleFormAscx
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
 
            FillInUserData(this.FieldContainer);
        }
        private void FillInUserData(System.Web.UI.Control control)
        {
            foreach (System.Web.UI.Control child in control.Controls)
            {
                if (child is BaseControl)
                {
                    if (child is InputControl)
                    {
                        InputControl field = (InputControl)child;
                        field.Text = Sitecore.Context.User.Profile.GetCustomProperty(field.ControlName);
                    }
                }
                FillInUserData(child);
            }
        }
    }
