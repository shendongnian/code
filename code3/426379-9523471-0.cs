        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                YrChkBox.Items.Add(new ListItem("Item 1", "Item1"));
                YrChkBox.Items.Add(new ListItem("Item 2", "Item2"));
            }
        }
        protected void YrChkBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> YrStrList = new List<string>();
            foreach (ListItem item in YrChkBox.Items)
                if (item.Selected)
                    YrStrList.Add(item.Value);
            String YrStr = String.Join(";", YrStrList.ToArray());
            Response.Write(String.Concat("Selected Items: ", YrStr));
        }
