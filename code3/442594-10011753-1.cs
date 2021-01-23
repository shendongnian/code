    public partial class AddressList : ICommonAddress
    {
        int id { get; set; }
        Mode mode { get; set; }
        Creator creator { get; set; }
        long[] siteList { get; set; }
        ATypeClass[] cspList;
        ICommonAddress CreateAddress()
        {
            return new AddressList();   // NOTE: you can even have your ctor private!
        }
    }
