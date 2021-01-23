    List<MyDataClass> myList = MyDataAccessLayer.GetFromDatabase();
    ListView1.DataSource = myList.Where(item => item.MyProperty1 == "value1");
    ListView1.DataBind();
    ...
    ListView10.DataSource = myList.Where(item => item.MyProperty1 == "value10");
    ListView10.DataBind();
