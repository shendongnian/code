    // Skip everything until we find 'Attributes;'.
    var stepOne = Player.PlayerList.SkipWhile(entry => entry != "Attributes;");
    // Skip over 'Attributes;'.
    var stepTwo = stepOne.Skip(1);
    // Take everything until we find '.'.
    var stepThree = stepTwo.TakeWhile(entry => entry != ".");
    // Stuff everything we selected into a new list.
    var typeAndAmount = stepThree.ToList();
