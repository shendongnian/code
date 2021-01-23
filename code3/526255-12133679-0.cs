    protected void Page_Load(object sender, EventArgs e)
    {
       ListItem listItem = new ListItem("Test 3");
       listItem.Attributes.Add("class", "class3");
       BulletedList1.Items.Add(listItem);
    }
