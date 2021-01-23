    protected void Page_Load(object sender, EventArgs e)
    {
       ListItem listItem = new ListItem("c");
       listItem.Attributes.Add("class", "class1");
       BulletedList1.Items.Add(listItem);
    }
