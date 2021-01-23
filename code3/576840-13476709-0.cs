    class MyListView : ListView {
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            if (this.DesignTime && this.Groups.Count == 0) {
                // Add the groups here
                //...
            }
        }
    }
