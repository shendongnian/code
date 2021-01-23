    var obj = array.Element.FirstOrDefault(x => x.Object.Length > 0);
    if (obj != null)
    {
      if (obj.Object[0].Item.Length != 0) 
      {
        // do whatever is necessary
      }
    }
