    var paramD = String.Empty;
    foreach (string arg in args)
    {
        switch (arg.Substring(0, 2).ToUpper())
        {
            case "/F":
                // process argument...
                break;
            case "/Z":
                // process arg...
                break;
            case "/D":
                paramD = arg.Substring(3);
                break;
            default:
                // do other stuff...
                break;
        }
    }
