    private static T GetReturnValue<T>(myClass x)
    {
        switch (x)
        {
            case 1:
                return Math.Sqrt(x.Field1);
                break;
            case 2:
                return Math.Pow(x.Field2,
                                2);
                break;
            default:
                return x.Field3;
                break;
        }
    }
