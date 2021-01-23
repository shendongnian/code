    protected void Page_Load(object sender, EventArgs e)
        {
            for (int index = 0; index < 10; index++)
            {
                ckbList2DesignationUc.Items.Add(new ListItem("Item" + index, index.ToString()));
            }
            foreach (ListItem Li in ckbList2DesignationUc.Items)
            {
                Li.Attributes.Add("onclick", "return itemClick()");
            }
    
        }
