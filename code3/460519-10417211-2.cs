    //need the first item for the type:
    var first = unknownValues.Cast<object>().First(); //obviously must NOT be empty :)
    var allDistinct = first.GetType()
      .GetProperties(BindingFlags.Public | BindingFlags.Instance)
      .Select(p => new 
        { 
          PropName = p.Name,
          Distinct = unknownValues.Cast<object>().Select(
            o => property.GetValue(o, null)
          ).Distinct() 
        });
