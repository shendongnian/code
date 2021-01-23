    public class MyPage : Page
    {
        protected override OnLoad( EventArgs e )
        {
            this.MyUserControl.Initialize( this.MyHiddenField );
        }
    }
    
    public class MyUserControl : UserControl
    {
        public void Initialize( HtmlInputHidden input )
        {
            // now child user control has access to the data without needing to know
            // about its parent
        }
    }
