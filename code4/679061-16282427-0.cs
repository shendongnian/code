    Binding bind = new Binding("List", myDataTable, "Name"){
      ControlUpdateMode = ControlUpdateMode.Never, //Because my List property is readonly
      DataSourceUpdateMode = DataSourceUpdateMode.Never//This will be turned on when preparing to change the List's value
    };
    //formating string data before updating to the datasource
    bind.Parse += (s,e) => {
      List<string> data = (List<string>) e.Value;
      if(data.Count == 0) e.Value = DBNull.Value;
      else e.Value = string.Join(",",data.ToArray());//format as comma separated string
      //At here reset the DataSourceUpdateMode to Never
      //We can also do this in BindingComplete event handler with BindingCompleteContext = BindingCompleteContext.DataSourceUpdate
      myCustomControl.DataBindings[0].DataSourceUpdateMode = DataSourceUpdateMode.Never;
    };
    myCustomControl.DataBindings.Add(bind);
