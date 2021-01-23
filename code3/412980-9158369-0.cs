    public class CustomBasePage: Page
    {
        readonly Type _t;
        protected override void OnInit(EventArgs e)
        {
            _t = Business.GetPageType();
        }
    }
