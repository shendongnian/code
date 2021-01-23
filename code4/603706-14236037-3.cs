    Type destinationType = null;
    switch value
    {
      case 0:
      destinationType  = typeof(JsonWorldRanking);
      break;
      case 1:
      destinationType  = typeof(JsonNationalRanking);
      break;
      case 2:
      destinationType  = typeof(JsonCountryRanking);
      break;
    }
    ...
    Type listType = typeof(List<>);
    Type[] typeArgs = {destinationType};
    type requiredGenericListType = listType.MakeGenericType(typeArgs);
    var deserialized = JsonConvert.Deserialize(r.EventArgs.Result, requiredGenericListType );
