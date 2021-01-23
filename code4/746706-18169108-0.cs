    public partial class MyView : System.Web.UI.UserControl
    {
        public event EventHandler SomethingButtonClick;
        
        protected void DoSomething_Click(object sender, EventArgs e)
        {
            //pass the event up to the aspx page. also called bubbling up the event.
            if (this.SomethingButtonClick != null)
                this.SomethingButtonClick(this, e);
        }
    }
