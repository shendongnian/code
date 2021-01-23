    class MyModel {
        public event EventHandler StopRefreshLoading;
    }
    class myForm : Form {
        public myForm(MyModel data)
        {
            data.StopRefereshLoading += (o, e) => this.CustomControl.StopPullToRefreshLoading(true);
            // ... etc
        }
