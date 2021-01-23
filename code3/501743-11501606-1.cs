    private interface IExtendable
    {
        Hashtable ExtendedProperties { get; }
    }
    private class Extendable: IExtendable
    {
        Hashtable ExtendedProperties { get; private set; }
    }
