    public class MyListBox : ListBox
    {
        private const int LB_ADDSTRING = 0x180;
        private const int LB_INSERTSTRING = 0x181;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == LB_ADDSTRING || m.Msg == LB_INSERTSTRING)
            {
                OnItemAdded(this, new EventArgs());
            }
            base.WndProc(ref m);
        }
        public event EventHandler ItemAdded;
        protected void OnItemAdded(object sender, EventArgs e)
        {
            if (ItemAdded != null)
                ItemAdded(sender, e);
        }
    }
