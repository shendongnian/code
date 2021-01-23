    //using a custom enum, calls the params T[] overload
    NodeGrid<MyCarEnum> carNode = ...
    carNode.IsPassable(MyCarEnum.Road, MyCarEnum.Tunnel);
    
    //demonstrates receiving a set of pass types strings from an external source
    List<string> passTypes = new List<string>("Path", "Floor", "Door");
    NodeGrid<string> personNode = ...
    personNode.IsPassable(passTypes) //calls the IEnumerable<T> overload
    
    //feel free to declare enums wherever you want, 
    //it can avoid potential mixups like this:
    NodeGrid<string> airplaneNode = ...
    NodeGrid<string> personNode = ...
    NodeGrid<MyCarEnum> carNode = ...
    airplaneNode.IsPassable("Floor"); //makes no sense, but will compile
    personNode.IsPassable("Clouds"); //makes no sense, but will compile
    carNode.IsPassable("Sky"); //compile error: was expected a MyCarEnum value
