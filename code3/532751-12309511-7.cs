    foreach (string arg in args)
    {
        bool grabNext = (arg == "-AA");
        if (grabNext)
        {
            incomingPlatypusID = arg;
            // probably better break now:
            break;
        }
    }
