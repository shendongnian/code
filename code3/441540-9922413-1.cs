    public class MyPage : Page
    {
        public HtmlInputHidden MyHiddenField
        {
            get{ return this.hdnField1; }
        }
    }
    
    public class MyUserControl : UserControl
    {
        protected override OnLoad( EventArgs e )
        {
            MyPage p = (MyPage)Page;
            HtmlInputHidden h = p.MyHiddenField;
        }
    }
