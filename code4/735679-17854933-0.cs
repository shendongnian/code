    var properties = objAcc.GetType().GetProperties();
    foreach(var property in properties)
    {
      if(props.Contains(property.Name))
      {
         //Do you stuff
      }
    }
