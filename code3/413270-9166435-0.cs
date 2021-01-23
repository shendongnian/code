        public List<string> NotAddedAssets
        {
            get
            {
                List<string> notAddedAssets = new List<string>();
                for (int i = 0; i < lbNotAddingAssets.Items.Count; i++)
                    notAddedAssets.Add(lbNotAddingAssets.Items[i].ToString());
                notAddedAssets.Sort();
                return notAddedAssets;
            }
            set
            {
                lbNotAddingAssets.AppendDataBoundItems = true;
                lbNotAddingAssets.Items.Clear();
                value.Sort();
                lbNotAddingAssets.DataSource = value;
                lbNotAddingAssets.DataBind();
            }
        }
        public List<string> AddedAssets
        {
            get
            {
                List<string> addedAssets = new List<string>();
                for (int i = 0; i < lbAddingAssets.Items.Count; i++)
                    addedAssets.Add(lbAddingAssets.Items[i].ToString());
                addedAssets.Sort();
                return addedAssets;
            }
            set
            {
                lbAddingAssets.AppendDataBoundItems = true;
                lbAddingAssets.Items.Clear();
                value.Sort();
                lbAddingAssets.DataSource = value;
                lbAddingAssets.DataBind();
            }
        }
