    // Skip everything until we find 'Attributes;'.
    var stepOne = Player.PlayerList.SkipWhile(entry => entry != "Attributes;");
    // Take everything until we find '.'.
    var stepTwo = stepOne.TakeWhile(entry => entry != ".");
    // Stuff everything we selected into a new list.
    var typeAndAmount = stepTwo.ToList();
