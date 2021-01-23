     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fill();
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> lst =
          new List<int>();
            lst.Add(12);
            lst.Add(22);
            lst.Add(32);
            DropDownList2.DataSource = lst;
            DropDownList2.DataBind();
        }
        private void fill()
        {
            List<int> lst =
            new List<int>();
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);
            var count=0;
            foreach (var i in lst)
            {
                DropDownList1.Items.Insert(count, new ListItem(i.ToString(), count.ToString()));
                count++;
            }
            
        }
