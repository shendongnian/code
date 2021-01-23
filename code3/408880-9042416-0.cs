    foreach (object item in Object) {
      switch (item.GetType().Name) {
        case "System.Int16":
          3rdPartyLibrary.Write((Int16)item);
          break;
        case "System.Int32":
          3rdPartyLibrary.Write((Int32)item);
          break;
        case "System.Boolean":
          3rdPartyLibrary.Write((bool)item);
          break;
        case "System.String":
          3rdPartyLibrary.Write((string)item);
          break;
        default:
          throw new ArgumentException("Unhandled type '" + item.GetType().Name + "'.");
    }
