    string values = "";
    foreach(ListItem item in myCBL.Items){
    if(item.Selected)
    {
    values += item.Value.ToString() + ",";  
    }
    }
    values = values.TrimEnd(',');  //To eliminate comma in last.
