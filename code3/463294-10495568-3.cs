    public class MyTest
    {
        private DataTable dt;
        public BindingListCollectionView View1 { get; set; }
        public BindingListCollectionView View2 { get; set; }
        public BindingListCollectionView View3 { get; set; }
        public BindingListCollectionView View4 { get; set; }
        private string _selected1;
        public string Selected1
        {
            get { return _selected1; }
            set { _selected1 = value;
                this.UpdateFilter();
            }
        }
        private void UpdateFilter()
        {
            this.View1.CustomFilter = GetFilter(this.Selected2, this.Selected3, this.Selected4);
            this.View2.CustomFilter = GetFilter(this.Selected1, this.Selected3, this.Selected4);
            this.View3.CustomFilter = GetFilter(this.Selected1, this.Selected2, this.Selected4);
            this.View4.CustomFilter = GetFilter(this.Selected1, this.Selected2, this.Selected3);
        }
        private string GetFilter(string selected2, string selected3, string selected4)
        {
            var filter = "";
            if (!string.IsNullOrWhiteSpace(selected2))
                filter = "Name <> '" + selected2 + "' and ";
            if(!string.IsNullOrWhiteSpace(selected3))
                filter += "Name <> '" + selected3 + "' and ";
            if (!string.IsNullOrWhiteSpace(selected4))
                filter += "Name <> '" + selected4 + "' and ";
            if (!string.IsNullOrWhiteSpace(filter))
                filter = filter.Substring(0, filter.Length - 4);
            return filter;
        }
        private string _selected2;
        public string Selected2
        {
            get { return _selected2; }
            set { _selected2 = value;
            this.UpdateFilter();
            }
        }
        private string _selected3;
        public string Selected3
        {
            get { return _selected3; }
            set { _selected3 = value;
            this.UpdateFilter();
            }
        }
        private string _selected4;
        public string Selected4
        {
            get { return _selected4; }
            set { _selected4 = value;
            this.UpdateFilter();
            }
        }
        public MyTest()
        {
            this.dt = new DataTable();
            this.dt.Columns.Add("Name");
            for (int i = 0; i < 15; i++)
            {
                var row = dt.NewRow();
                row["Name"] = "Name " + i;
                dt.Rows.Add(row);
            }
            View1 = new BindingListCollectionView(new DataView(dt));
            View2 = new BindingListCollectionView(new DataView(dt));
            View3 = new BindingListCollectionView(new DataView(dt));
            View4 = new BindingListCollectionView(new DataView(dt));
        }
    }
