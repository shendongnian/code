    Func<ListItem, object> getNotNullField;
    if (...) {
        getNotNullField = item => item.Countries;
    } else {
        getNotNullField = item => item.SomeOtherField;
    }
    ...
    var itemsFromList = from item in ListItems where getNotNullField(item) != null 
                        select item;   
