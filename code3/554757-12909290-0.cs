    public partial class JobControl
    {
        public void CallGroupChanged(object sender, EventArgs e)
        {
            // do your work
            if (this.MyEventDelegate != null) // check if the event is not null
                this.MyEventDelegate(this, null); // invoke it
        }
        public event EventHandler MyEventDelegate;
    }
