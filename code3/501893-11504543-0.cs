    foreach (var elem in myDict)
    {
        //I need to make some modifications in inner Dictionary for chosen myEnum
        Dictionary<myEnum, secondObject> inner = elem.Value;
        inner[myEnum.EnumVal1] = new secondObject(123);
        inner[myEnum.EnumVal2] = new secondObject(456);
    }
