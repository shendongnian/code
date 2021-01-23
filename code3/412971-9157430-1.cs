    public partial class MyWindowsFormsForm()
    {
        public MyWindowsFormsForm()
        {
            this.WebBrowserControl.ObjectForScripting = this;
        }
    
        public void DoSomething()
        {
            MyOtherForm f = new MyOtherForm();
            f.Show();
        }
    }
