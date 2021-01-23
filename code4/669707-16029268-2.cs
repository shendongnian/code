        protected override void OnInit(EventArgs e)
        {          
            RadioButtonList1.Items.AddRange(GetItems());
            base.OnInit(e);
        }
        private ListItem[]  GetItems()
        {
                return new ListItem[] {
                        new ListItem("Item 1", "1"),
                        new ListItem("Item 2", "2"),
                        new ListItem("Item 3", "3"),
                        new ListItem("Item 4", "4")
                });
        }
