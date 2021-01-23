    PropertyInfo piTheList = MyObject.GetType().GetProperty("TheList"); //Gets the properties
    IList oTheList = piTheList.GetValue(MyObject, null) as IList;
    //Now that I have the list object I extract the inner class and get the value of the property I want
    PropertyInfo piTheValue = piTheList.PropertyType.GetGenericArguments()[0].GetProperty("TheValue");
    foreach (var listItem in oTheList)
    {
        object theValue = piTheValue.GetValue(listItem, null);
        piTheValue.SetValue(listItem,"new",null);  // <-- set to an appropriate value
    }
