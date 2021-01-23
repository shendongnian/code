    // be sure to register the event in the page!
    public class MyPage : Page
    {
        protected override void OnLoad(object sender, EventArgs e)
        {
            base.OnLoad(sender, e);
            myUserControl.OnSomeButtonPressed += this.HandleUserControl_ButtonClick;
        }
        public string HandleUserControl_ButtonClick(object sender, EventArgs e)
        {
            return this.SomeTextBox.Text;
        }
    }
