    Classes.DaysOfWeek _DaysOfWeek;
    
    _DaysOfWeek = new Classes.DaysOfWeek();
    var listProp = _DaysOfWeek.GetType().GetProperties().ToList();
    
    List<String> newList = new List<String>{};
    foreach(var item in listProp){
    newList.Add(item.Name);
    }
    listBox_Days.ItemsSource = newList;
