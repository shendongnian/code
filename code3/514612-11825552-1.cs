    protected void Page_Load(object sender, EventArgs e)
    {
        var objects =
            new object[] {
                new {SomeID = 1},
                new {SomeID = 2},
                new {SomeID = 3},
                new {SomeID = 4}
            };
        repTest.DataSource = objects;
        repTest.DataBind();
    }
    protected void btnClick(object sender, EventArgs e)
    {
        var data = (object[])repTest.DataSource;
        foreach (RepeaterItem item in repTest.Items)
        {
            var obj = data[item.ItemIndex];
            var id = obj.GetType().GetProperty("SomeID").GetValue(obj, null);
        }
    }
