       List<X> newList = new List<X>();
       foreach(var item in origList)
       {
          newList.Add(new X {value = item.Value, 
                             text = Capitalize(item.Value)
                            });
       }
    
       dropdownlist.DataSource = newList;
