    //when populating your List, before adding each SomeItem subscribe to IPropertyChanged 
    var newItem = new SomeItem();//..some properties I assume
     newItem.PropertyChanged += (s,e) =>
     {
         switch(e.PropertyName)
         {
              case "Column#4Property" :
             //Do work thta responds to that property changed
             break;
      }
      _myList.Add(newItem);
