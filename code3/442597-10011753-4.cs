    // if your original partial class is auto-generated, it is ok to place 
    // this definition in another file, it'll still work as long as 
    // namespace, classname and compile-unit (must be in same project) are the same
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
