    public class MyCheckedListBox : CheckedListBox
    {
        public event ItemCheckEventHandler ItemCheckedChanged;
        protected virtual void OnItemCheckedChanged(ItemCheckEventArgs ice)
        {
            var h = ItemCheckedChanged;
            if (h != null)
                h(this, ice);
        }
        protected override void OnItemCheck(ItemCheckEventArgs ice)
        {
            base.OnItemCheck(ice);
            ThreadPool.QueueUserWorkItem(new WaitCallback((state) =>
                {
                    this.BeginInvoke(new Action<ItemCheckEventArgs>(OnItemCheckedChanged), ice);
                }));
        }
