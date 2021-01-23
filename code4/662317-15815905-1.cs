    public partial class MyUserControl : UserControl
    {
        /// You can name the event anything you want.
        public event EventHandler ButtonSelected;
        /// This bubbles the button selected event up to the form.
        private void Button1_Clicked(object sender, EventArgs e)
        {
             if (this.ButtonSelected != null)
             {
                  // You could pass your own custom arguments back to the form here.
                  this.ButtonSelected(this, e)
             }
        }
    }
