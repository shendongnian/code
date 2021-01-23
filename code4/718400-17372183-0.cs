    string[][] rootAndKey = new string[allRoots.Length][];
    for(var i = 0; i < allRoots.Count; i++)
    {
        var subkeys = root.GetSubKeyNames();
        rootAndKey[i] = new string[subkeys.Length];
        for(var h = 0; h < subkeys.Length; h++)
        {
            rootAndKey[i][h] = subkeys[h];
        }
    }
