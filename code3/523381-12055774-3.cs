    class MyClass
    {
        public delegate void NewListEntryEventHandler(
            object sender,
            NewListEntryEventArgs args);
        public event NewListEntryEventHandler NewListEntry;
        protected virtual void OnNewListEntry(string test)
        {
            if (NewListEntry != null)
            {
                NewListEntry(this, new NewListEntryEventArgs(test));
            }
        }
    }
