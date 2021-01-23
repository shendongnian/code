    using (var context = new YourEntities()) 
    {
        var query = from x in context.Registrations
                    select x; //Just an example, selecting everything.
        List<Registration> MyList = query.ToList();
        foreach (Registration reg in MyList) //Can also be "var reg in MyList"
        {
            MyDropDownList.Items.Add(new ListItem(reg.LastName + ", " + reg.FirstName, reg.ID));
            //Or do whatever you want to each List Item
        }
    }
