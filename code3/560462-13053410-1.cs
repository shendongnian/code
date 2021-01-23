    IList gdb;
    switch (trail[dataPos].Type)
    {
        case GlobalsSubscriptTypes.Int32:
            gdb = new List<int>();
            break;
        case GlobalsSubscriptTypes.Int64:
            gdb = new List<long>();
            break;
        default:
            gdb = new List<string>();
            break;
    }
