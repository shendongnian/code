    [DefaultEvent("MyClick")]
    public partial class UCPersonSearch : UserControl
    {
        Button btnSearch;
        public event EventHandler MyClick;
        public UCPersonSearch()
        {
            btnSearch = new Button();
            //...
            btnSearch.Click += new EventHandler(btnSearch_Click);
        }
        void btnSearch_Click(object sender, EventArgs e)
        {
            OnMyClick();
        }
        protected virtual void OnMyClick()
        {
            var h = MyClick;
            if (h != null)
                h(this, EventArgs.Empty);
        }
    }
