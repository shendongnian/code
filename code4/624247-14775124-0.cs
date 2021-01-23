    var blockIdentifier = new Dictionary<string, Type>();
    blockIdentifier.Add("=", typeof(BlockDirt));
    blockIdentifier.Add("-", typeof(BlockAir));
    
    ....
    
    mapList[x,y] = blockIdentifier[symbol].GetConstructor(new Type[] { }).Invoke(null);
