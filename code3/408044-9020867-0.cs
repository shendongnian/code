    public class ThemePage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            SetTheme();            
            
            base.OnPreInit(e);
        }
        private void SetTheme()
        {
            this.Theme = ThemeSwitcher.GetCurrentTheme();
        }
    }
