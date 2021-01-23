        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate the CheckBoxList items only when it's not a postback.
                YrChkBox.Items.Add(new ListItem("Item 1", "Item1"));
                YrChkBox.Items.Add(new ListItem("Item 2", "Item2"));
            }
        }
        protected void YrChkBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Create the list to store.
            List<String> YrStrList = new List<string>();
            // Loop through each item.
            foreach (ListItem item in YrChkBox.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    YrStrList.Add(item.Value);
                }
                else
                {
                    // Item is not selected, do something else.
                }
            }
            // Join the string together using the ; delimiter.
            String YrStr = String.Join(";", YrStrList.ToArray());
            // Write to the page the value.
            Response.Write(String.Concat("Selected Items: ", YrStr));
        }
